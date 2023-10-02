using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF
{
    public partial class UserControlLogin : UserControl
    {
        private MainWindow mainWindow;

        public UserControlLogin()
        {
            InitializeComponent();
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        private bool _isLoginSuccessful = false;

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                mainWindow.ShowHomeScreen();
            }
        }

        private bool IsValid()
        {
            Constants.Sql.User = UserNameBox.Text;
            Constants.Sql.Password = PasswordBox.Password;

            if (string.IsNullOrEmpty(UserNameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Please enter a username and password");
                _isLoginSuccessful = false;
            }
            else
            {
                try
                {
                    DatabaseServer.ExecuteQuery("SELECT * FROM Users");
                    var test = DatabaseServer.FetchVehicle(8);
                   // MessageBox.Show(test.ToString());
                   _isLoginSuccessful = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("User does not exist");
                    _isLoginSuccessful = false;
                }
                
            }
            
            
            return _isLoginSuccessful;
        }

        private void CreatUser_OnClick(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowCreateUserScreen();
        }
    }
}