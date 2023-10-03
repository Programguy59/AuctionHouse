using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class BidHistoryControl : UserControl
{
    private MainWindow mainWindow;
    public BidHistoryControl(MainWindow main)
    {
        InitializeComponent();
        this.mainWindow = main;
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.mainWindow.ShowHomeScreen();
    }
}