using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class BuyerOfAuctionControl : UserControl
{
    private MainWindow mainWindow;
    public BuyerOfAuctionControl(MainWindow main)
    {
        InitializeComponent();
        this.mainWindow = main;
    }

    private void PlaceBidButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}