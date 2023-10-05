using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF;

public partial class UserControlHomepage : UserControl
{
    private readonly MainWindow mainWindow;

    public UserControlHomepage(MainWindow main)
    {
        InitializeComponent();
        mainWindow = main;

        CurrentAuctionsList.Items.Clear();
        YourAuctionsList.Items.Clear();

        var yourAuctionList = new ObservableCollection<Auction>();
        var othersAuctionList = new ObservableCollection<Auction>();

        foreach (var auction in Database.Auctions)
            if (auction.Seller.UserName == Database.GetUserByUserName(Constants.Sql.User)?.UserName)
                yourAuctionList.Add(auction);
            else if (!auction.isDone) othersAuctionList.Add(auction);

        YourAuctionsList.ItemsSource = yourAuctionList;
        CurrentAuctionsList.ItemsSource = othersAuctionList;
    }

    private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowUserProfileScreen();
    }

    private void CreateAuctionButton_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowSetForSaleScreen();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var selectedAuction = (sender as Button).DataContext as Auction;

        if ((sender as Button)?.Tag.ToString() == "Buyer")
            mainWindow.ShowBuyerOfAuctionScreen(selectedAuction);
        else if ((sender as Button)?.Tag.ToString() == "Seller") mainWindow.ShowSellerOfAuctionScreen(selectedAuction);
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        Database.Auctions.Clear();
        Database.BidHistory.Clear();
        DatabaseServer.Initialize(0);

        YourAuctionsList.ItemsSource = null;
        CurrentAuctionsList.ItemsSource = null;


        CurrentAuctionsList.Items.Clear();
        CurrentAuctionsList.Items.Refresh();
        YourAuctionsList.Items.Clear();
        YourAuctionsList.Items.Refresh();


        var yourAuctionList = new ObservableCollection<Auction>();
        var othersAuctionList = new ObservableCollection<Auction>();


        foreach (var auction in Database.Auctions)
            if (auction.Seller.UserName == Database.GetUserByUserName(Constants.Sql.User)?.UserName)
                yourAuctionList.Add(auction);
            else if (!auction.isDone) othersAuctionList.Add(auction);

        YourAuctionsList.ItemsSource = yourAuctionList;
        CurrentAuctionsList.ItemsSource = othersAuctionList;

        CurrentAuctionsList.Items.Refresh();
        YourAuctionsList.Items.Refresh();
    }
}