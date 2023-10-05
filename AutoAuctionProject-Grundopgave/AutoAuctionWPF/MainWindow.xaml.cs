using System;
using System.Media;
using System.Windows;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        try
        {
            var player = new SoundPlayer("../../../music/TwoTrucks.wav");

            player.PlayLooping();
        }
        catch (Exception ex)
        {
            // Handle the exception, e.g., log it or show an error message
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        DatabaseServer.Initialize(0);

        ShowLoginScreen(); // Start med at vise Login-skærmen
    }


    public void ShowLoginScreen()
    {
        contentControl.Content = new UserControlLogin(this);
    }

    public void ShowHomeScreen()
    {
        contentControl.Content = new UserControlHomepage(this);
    }

    public void ShowCreateUserScreen()
    {
        contentControl.Content = new CreateUserControl(this);
    }

    public void ShowSetForSaleScreen()
    {
        contentControl.Content = new SetForSaleControl(this);
    }

    public void ShowBuyerOfAuctionScreen(Auction auction)
    {
        contentControl.Content = new BuyerOfAuctionControl(this, auction);
    }

    public void ShowSellerOfAuctionScreen(Auction auction)
    {
        contentControl.Content = new SellerOfAuctionControl(this, auction);
    }

    public void ShowUserProfileScreen()
    {
        contentControl.Content = new UserProfileControl(this);
    }

    public void BidHistoryControl()
    {
        contentControl.Content = new BidHistoryControl(this);
    }
}