using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Banking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var info = new CornUI.Controls.CwndInfo();
            var themeKey = Model.Theme.GetInstance(info);
            View.MainWin wnd = new View.MainWin(info);
            View.MainWin wnd2 = new View.MainWin(info);
            wnd.Show();
            wnd2.Show();
        }
    }
}
