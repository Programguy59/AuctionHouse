using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class SetForSaleControl : UserControl
{
    private MainWindow mainWindow;
    public SetForSaleControl(MainWindow main)
    {
        InitializeComponent();
        this.mainWindow = main;
    }

    private void SetForSaleButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}