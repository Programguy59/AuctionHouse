using AutoAuctionProjekt.Classes;
using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class SellerOfAuctionControl : UserControl
{
    private MainWindow mainWindow;
    public SellerOfAuctionControl(MainWindow main, Auction auction)
    {
        InitializeComponent();
        this.mainWindow = main;
    }

    private void AcceptBidButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}