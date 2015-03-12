using System;
using System.Windows;
using System.Windows.Controls;


namespace Installer.Views
{
    public partial class ProgressView : UserControl
    {
        private readonly ProgressPresenter presenter;


        public ProgressView(ProgressPresenter presenter)
        {
            InitializeComponent();
            DataContext = Presenter.Model;

            this.presenter = presenter;
        }


        public void BeginInstallation()
        {
            presenter.BeginInstallation();
        }


        private void NextClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangeNextView();
        }

        private void DetailsSizeChanged(object sender, SizeChangedEventArgs e)
        {
            detailsScroll.ScrollToEnd();
        }

        private void ProgressValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (progress.Value == progress.Maximum)
            {
                nextButton.IsEnabled = true;
            }
            else
                nextButton.IsEnabled = false;
        }
    }
}
