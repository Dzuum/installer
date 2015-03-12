using System;
using System.Windows;
using System.Windows.Controls;


namespace Installer.Views
{
    public partial class LicenseView : UserControl
    {
        private readonly Presenter presenter;


        public LicenseView(Presenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }


        private void NextClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangeNextView();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangePreviousView();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            presenter.CloseProgram();
        }
    }
}
