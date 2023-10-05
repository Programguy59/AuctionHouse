using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;

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
            ChangeCredit.Visibility = Visibility.Visible;


        }



    }

    private void backButton_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ShowHomeScreen();
    }

    private void ChangeBalance_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ChangeCredit_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ShowBidHistory_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.BidHistoryControl();
    }
}