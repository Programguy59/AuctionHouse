using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Data;

namespace AutoAuctionWPF;

public partial class UserProfileControl : UserControl
{
    private MainWindow _mainWindow;
    private User _user;
    public UserProfileControl(MainWindow mainWindow)
    {
        InitializeComponent();



        _mainWindow = mainWindow;
        _user = Database.GetUserByUserName(Constants.Sql.User);
        UserInfoPanel.DataContext = _user;
        if (_user.IsCorporate)
        {
            UserInfoPanel.DataContext = Database.GetCorporateUserByUserName(Constants.Sql.User);
            CreditBox.Visibility = Visibility.Visible;


        }



    }

    private void backButton_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ShowHomeScreen();
    }

    private void ChangeBalance_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            _user.Balance += Convert.ToDecimal(BalanceChangeAmount.Text);
            UserInfoPanel.DataContext = null;
            UserInfoPanel.DataContext = _user;
            BalanceChangeAmount.Clear();

            DatabaseServer.UpdateBalance(_user.UserName, _user.Balance);

        }
        catch (System.Exception)
        {

            MessageBox.Show("Input is not a number");
        }
    }
}

 