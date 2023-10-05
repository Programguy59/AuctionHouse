using AutoAuctionProjekt.Classes;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF;

public partial class SellerOfAuctionControl : UserControl
{
    private MainWindow mainWindow;
    private Auction auction;
    public SellerOfAuctionControl(MainWindow main, Auction auction)
    {
        InitializeComponent();
        this.mainWindow = main;
        this.auction = auction;
        AuctionNameTextBlock.Text = auction.Vehicle.Name;
        AuctionInfoTextBlock.Text = auction.StandingBid.ToString();

    }

    private void AcceptBidButton_Click(object sender, RoutedEventArgs e)
    {
        AuctionHouse.AcceptBid(Database.GetUserByUserName(Constants.Sql.User), auction.ID);
        mainWindow.ShowHomeScreen();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowHomeScreen();
    }
    
}