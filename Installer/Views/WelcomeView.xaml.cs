using System;
using System.Windows;
using System.Windows.Controls;


namespace Installer.Views
{
    public partial class WelcomeView : UserControl
    {
        private readonly Presenter presenter;


        public WelcomeView(Presenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }


        private void NextClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangeNextView();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            presenter.CloseProgram();
        }
    }
}
