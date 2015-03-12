using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Installer.Views;


namespace Installer
{
    public partial class Shell : Window
    {
        private readonly List<UserControl> views = new List<UserControl>();
        private int currentView;

        public ContentControl View
        {
            get { return view as ContentControl; }
            set { view = value; }
        }


        public Shell()
        {
            InitializeComponent();

            //Luomalla kerralla tarvittavat (vähäiset ikkunat),
            //voidaan niiden tiloja pitää yllä navigoitaessa
            views.Add(new WelcomeView(new Presenter(this)));
            views.Add(new LicenseView(new Presenter(this)));
            views.Add(new DirectorySelectView(new DirectorySelectPresenter(this)));
            views.Add(new ProgressView(new ProgressPresenter(this)));
            views.Add(new FinishView(new Presenter(this)));

            currentView = 0;
            View.Content = views[currentView];
        }


        public void ChangeNextView()
        {
            if (View.Content is FinishView)
                this.Close();
            else
            {
                currentView++;
                View.Content = views[currentView];

                //Erikoistoimintona asennus aloitetaan, kun vaihdetaan ProgressViewiin
                if (View.Content is ProgressView)
                {
                    ProgressView progressView = View.Content as ProgressView;
                    progressView.BeginInstallation();
                }
            }
        }

        public void ChangePreviousView()
        {
            currentView--;
            if (currentView < 0)
                currentView = 0;

            View.Content = views[currentView];
        }


        private void WindowClosing(object sender, CancelEventArgs e)
        {
            //Varmistetaan, ettei käyttäjä sulje asennusohjelmaa turhan helposti.
            //Mieluummin koko sulkemisnappi vähintäänkin laitettaisiin pois päältä,
            //mutta WPF ei näytä tarjoavan siihen suoraa tapaa.
            if (view.Content is ProgressView)
            {
                e.Cancel = true;
                return;
            }

            //Varmistetaan, että käyttäjä haluaa poistuaa, jos asennus ei ole valmis
            if (View.Content is FinishView == false)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Are you sure you want to exit the installer?",
                    "Generic Installer 9k1",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                    e.Cancel = true;
            }
            else //Ikkuna sulkeutumassa FinishView'ssä
            {
                //Haluttaessa avataan asennuskansio
                FinishView finishView = views[currentView] as FinishView;
                if (finishView != null)
                    if (finishView.openCheckbox.IsChecked == true)
                        Process.Start(finishView.InstallDirectory);
            }
        }
    }
}
