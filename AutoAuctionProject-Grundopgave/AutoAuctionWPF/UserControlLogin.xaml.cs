using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Util;


namespace AutoAuctionWPF;

public partial class UserControlLogin : UserControl
{
    public UserControlLogin()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    string _userName;
    string _password;

    private void Login_OnClick(object sender, RoutedEventArgs e)
    {
        Constants.Sql.User = UserNameBox.Text;
        Constants.Sql.Password = PasswordBox.Password;
        if (string.IsNullOrEmpty(UserNameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
        {
            MessageBox.Show("Please enter a username and password");
        }
        else
        {
            DatabaseServer.ExecuteQuery("SELECT * FROM Users");
            var test = DatabaseServer.FetchVehicle(8);
            MessageBox.Show(test.ToString());
                MessageBox.Show("Login successful");
        }
        
        

    }

}
    