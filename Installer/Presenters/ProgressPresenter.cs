using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using Installer.Views;


namespace Installer
{
    public class ProgressPresenter : Presenter
    {
        public ProgressPresenter(Shell shell)
            : base(shell)
        {
        }


        public void BeginInstallation()
        {
            Thread thread = new Thread(new ThreadStart(() => Model.InstallFiles(this)));
            thread.Start();
        }
    }
}
