using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class UserControlHomepage : UserControl
{
    private MainWindow mainWindow;
    public UserControlHomepage(MainWindow main)
    {
        InitializeComponent();
        mainWindow = main;

        CurrentAuctionsList.Items.Clear();

        ObservableCollection<Auction> auctionList = new ObservableCollection<Auction>();

        foreach (Auction auction in Database.Auctions)
        {
            auctionList.Add(auction);
        }

        CurrentAuctionsList.ItemsSource = auctionList;


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
        Auction selectedAuction = (sender as Button).DataContext as Auction;

        mainWindow.ShowBuyerOfAuctionScreen(selectedAuction);
    }
}