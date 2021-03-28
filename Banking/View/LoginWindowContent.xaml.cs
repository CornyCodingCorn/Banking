using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Banking.View
{
    /// <summary>
    /// Interaction logic for WindowContent.xaml
    /// </summary>
    public partial class LoginWindowContent : UserControl
    {
        protected ViewModel.LoginViewModel loginViewModel;

        public LoginWindowContent()
        {
            InitializeComponent();
            loginViewModel = new ViewModel.LoginViewModel();
            this.DataContext = loginViewModel;
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(usernameTextBox.Text) || String.IsNullOrWhiteSpace(passwordBox.Password))
            {
                Debug.WriteLine("Please enter username and password.");
            }
            else
            {
                loginViewModel.AttemptLogin(usernameTextBox.Text, passwordBox.Password);
                Debug.WriteLine(errorMessage.Text);
            }

        }
    }
}
