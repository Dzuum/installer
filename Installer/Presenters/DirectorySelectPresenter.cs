using System;
using System.Windows.Controls;
using System.Windows.Forms;
using Installer.Views;


namespace Installer
{
    public class DirectorySelectPresenter : Presenter
    {
        DirectorySelectView view;


        public DirectorySelectPresenter(Shell shell)
            : base(shell)
        {
        }


        public void InjectView(ContentControl view)
        {
            this.view = view as DirectorySelectView;
        }

        public void SelectDirectory()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Model.InstallDirectory = dialog.SelectedPath;
            }
        }

        public void InstallSpaceUpdated()
        {
            Model.CalculateSpace();
        }

        public void BeginInstall()
        {
            if (CanBeginInstall())
            {
                this.ChangeNextView();
            }
        }

        private bool CanBeginInstall()
        {
            Model.CalculateInstallationDirectorySize();
            Model.CalculateSpace();

            if (Model.HasSufficientSpace)
                return true;
            else
                return false;
        }
    }
}
