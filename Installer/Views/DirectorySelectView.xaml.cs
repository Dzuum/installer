using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Installer.Views
{
    public partial class DirectorySelectView : UserControl
    {
        private readonly DirectorySelectPresenter presenter;


        public DirectorySelectView(DirectorySelectPresenter presenter)
        {
            InitializeComponent();
            DataContext = Presenter.Model;

            this.presenter = presenter;
            this.presenter.InjectView(this);
        }


        private void NextClick(object sender, RoutedEventArgs e)
        {
            presenter.BeginInstall();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangePreviousView();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            presenter.CloseProgram();
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            presenter.SelectDirectory();
        }

        private void AvailableSpaceUpdated(object sender, DataTransferEventArgs e)
        {
            presenter.InstallSpaceUpdated();
        }

        private void RequiredSpaceUpdated(object sender, DataTransferEventArgs e)
        {
            presenter.InstallSpaceUpdated();
        }
    }
}
