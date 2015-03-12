using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;


namespace Installer
{
    public class Model : INotifyPropertyChanged
    {
        public static readonly string DefaultInstallDirectory;
        private static readonly string SourceDirectory;


        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        private string installDirectory;
        public string InstallDirectory
        {
            get { return installDirectory; }
            set
            {
                installDirectory = value;
                OnPropertyChanged("InstallDirectory");

                availableSpace = GetPathAvailableBytes(installDirectory);
                OnPropertyChanged("AvailableSpace");
            }
        }

        private int filesToBeCopied;
        private int installCompletion;
        public int InstallCompletion
        {
            get { return installCompletion; }
            private set
            {
                installCompletion = value;

                OnPropertyChanged("InstallCompletion");
            }
        }

        private string currentOperation;
        public string CurrentOperation
        {
            get { return currentOperation; }
            private set
            {
                currentOperation = value;
                OperationHistory += "\n" + value;
                OnPropertyChanged("CurrentOperation");
            }
        }

        private string operationHistory;
        public string OperationHistory
        {
            get { return operationHistory; }
            private set
            {
                operationHistory = value;
                OnPropertyChanged("OperationHistory");
            }
        }

        private long availableSpace;
        public string AvailableSpace
        {
            get
            {
                return BytesToFormattedString(availableSpace);
            }
        }

        private long requiredSpace;
        public string RequiredSpace
        {
            get
            {
                return BytesToFormattedString(requiredSpace);
            }
        }

        private bool hasSufficientSpace;
        public bool HasSufficientSpace
        {
            get { return hasSufficientSpace; }
            set
            {
                hasSufficientSpace = value;
                OnPropertyChanged("HasSufficientSpace");
            }
        }
        #endregion


        static Model()
        {
            DefaultInstallDirectory = @"C:\Program Files\";
            SourceDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Tiedostot";
        }

        public Model()
        {
            InstallDirectory = DefaultInstallDirectory;

            if (filesToBeCopied == 0)
                installCompletion = 100;
            else
                installCompletion = 0;

            currentOperation = "Installing...";
            operationHistory = currentOperation;
        }


        public void InstallFiles(ProgressPresenter caller)
        {
            CopyDirectory(caller, SourceDirectory, installDirectory);

            CurrentOperation = "Finished!";
        }

        public void CalculateInstallationDirectorySize()
        {
            IEnumerable<FileInfo> info = (new DirectoryInfo(SourceDirectory))
                .EnumerateFiles("*.*", SearchOption.AllDirectories);

            filesToBeCopied = info.Count();

            requiredSpace = info.Sum(fi => fi.Length);
            OnPropertyChanged("RequiredSpace");
        }

        public bool CalculateSpace()
        {
            if (availableSpace == 0)
                HasSufficientSpace = false;
            else if (availableSpace >= requiredSpace)
                HasSufficientSpace = true;
            else
                HasSufficientSpace = false;

            return HasSufficientSpace;
        }


        //Tarvittiin, kun ongelmia pituuksien kanssa, esim. jokin olemassa oleva 
        //kansio johonkin lyhyempään osoitteeseen (esim. C:\A\) niin tulee Exception
        //pituuden ylittämisestä, vaikka käytännössä pitäisi olla mahdollista.
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists);


        DirectoryInfo currentDirectory;
        DirectoryInfo[] subDirectories;
        string[] files;
        string fileName;

        private int CopyDirectory(ProgressPresenter caller, string sourceDirectory,
            string destinationDirectory, int copied = 0)
        {
            currentDirectory = new DirectoryInfo(sourceDirectory);
            subDirectories = currentDirectory.GetDirectories();

            //Luodaan kansio, jos sitä ei ole olemassa
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            CurrentOperation = "Current directoy: " + destinationDirectory;
            
            //Kopioidaan kansion tiedostot ja päivitetään edistyminen
            files = Directory.GetFiles(sourceDirectory);
            foreach (string file in files)
            {
                fileName = Path.GetFileName(file);

                CurrentOperation = "Copying file: " + fileName;

                //CopyFile ei kirjoita olemassa olevien tiedostojen yli, koska kolmas parametri true
                if (!CopyFile(Path.Combine(sourceDirectory, fileName),
                    Path.Combine(destinationDirectory, fileName), true))
                {
                    CurrentOperation = "File skipped (already exists)";
                }

                copied++;
                InstallCompletion = (int)(((float)copied / (float)filesToBeCopied) * 100.0f);
            }
            
            //Käydään rekursion avulla läpi kaikki alikansiot
            //Pidetään myös mukana kopioitujen tiedostojen lukumäärä, count
            foreach (DirectoryInfo directory in subDirectories)
            {
                copied = CopyDirectory(caller, directory.FullName,
                    Path.Combine(destinationDirectory, directory.Name), copied);
            }

            return copied;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private long GetPathAvailableBytes(string path)
        {
            //Käytetään hyväksi Path.GetFullPath heittämiä poikkeuksia polun tarkistusta varten
            bool errorInPath = false;
            try
            {
                string fullPath = Path.GetFullPath(path);
            }
            catch (Exception e)
            {
                errorInPath = true;
            }

            if (errorInPath)
                return 0;

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (path.StartsWith(drive.Name))
                {
                    return drive.AvailableFreeSpace;
                }
            }

            return 0;
        }

        private string BytesToFormattedString(long bytes)
        {
            string unit = "B";
            double formattedSpace = bytes;

            if (formattedSpace / 1024.0d > 1)
            {
                formattedSpace /= 1024.0d;
                unit = "kB";

                if (formattedSpace / 1024.0d > 1)
                {
                    formattedSpace /= 1024.0d;
                    unit = "MB";

                    if (formattedSpace / 1024.0d > 1)
                    {
                        formattedSpace /= 1024.0d;
                        unit = "GB";

                        if (formattedSpace / 1024.0d > 1)
                        {
                            formattedSpace /= 1024.0d;
                            unit = "TB";
                        }
                    }
                }
            }

            return string.Format("{0:0.00} {1}", formattedSpace, unit);
        }
    }
}
