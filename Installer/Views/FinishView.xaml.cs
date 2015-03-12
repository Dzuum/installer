using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Installer.Views
{
    public partial class FinishView : UserControl
    {
        private readonly Presenter presenter;

        public string InstallDirectory { get { return presenter.InstallDirectory; } }


        public FinishView(Presenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }


        private void NextClick(object sender, RoutedEventArgs e)
        {
            presenter.ChangeNextView();
        }

        private void TextBlockMousePressed(object sender, MouseButtonEventArgs e)
        {
            openCheckbox.IsChecked = !openCheckbox.IsChecked;
        }
    }
}
