using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Banking.Model;

namespace Banking.ViewModel
{
    public class LoginViewModel : BaseINPC
    {
        #region Private fields and public Properties

        private RelayCommand _loginCommand;

        public ICommand LoginCommand => _loginCommand;

        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        private string _username;
        
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public bool CanPressLogin
        {
            get => !(String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password));
        }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            this._loginCommand = new RelayCommand(Login, GetCanPressLogin);
        }

        #endregion

        #region Public Authenticate and Login Method to expose to Views

        public void AttemptLogin(string username, string password)
        {
            // Authentication code
            //

            // Login
            this.Username = username; // To be removed, since Username would have been bound
            this.Password = password;
            Login();
        }

        #endregion

        #region Private Login Method

        private void Login()
        {
            Account account;
            // account.Username = this.Username; account.Password = this.Password;

            // Login 
            //
            ErrorMessage = "Login successful";
        }

        #endregion

        #region Some stupid function I wrote cus idk how else 

        private bool GetCanPressLogin(object obj)
        {
            return this.CanPressLogin;
        }

        #endregion
    }
}
