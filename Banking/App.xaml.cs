using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Banking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Start(object sender, StartupEventArgs e)
        {
            View.MainWin window = new View.MainWin();
            View.MainWin window2 = new View.MainWin();
            window.Show();
            window.CwndTitle = "Nhà Bank";
            window2.Show();
        }
    }
}
