using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF;

public partial class UserControlLogin : UserControl
{
    private bool _isLoginSuccessful;
    private readonly MainWindow mainWindow;

    public UserControlLogin(MainWindow main)
    {
        InitializeComponent();
        mainWindow = (MainWindow)Application.Current.MainWindow;
    }

    private void Login_OnClick(object sender, RoutedEventArgs e)
    {
        if (IsValid())
        {
            mainWindow.ShowHomeScreen();
            DatabaseServer.FetchUser(UserNameBox.Text);
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