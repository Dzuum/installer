using System;
using System.Windows;
using Installer.Views;


namespace Installer
{
    public class Presenter
    {
        protected readonly Shell shell;
        public static readonly Model Model;

        public string InstallDirectory { get { return Model.InstallDirectory; } }


        static Presenter()
        {
            Model = new Model();
            Model.CalculateInstallationDirectorySize();
        }

        public Presenter(Shell shell)
        {
            this.shell = shell;
        }


        public void ChangeNextView()
        {
            shell.ChangeNextView();
        }

        public void ChangePreviousView()
        {
            shell.ChangePreviousView();
        }

        public void CloseProgram()
        {
            shell.Close();
        }
    }
}
