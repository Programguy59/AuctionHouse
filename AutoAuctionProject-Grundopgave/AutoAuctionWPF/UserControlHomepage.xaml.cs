using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class UserControlHomepage : UserControl
{
    private MainWindow mainWindow;
    public UserControlHomepage()
    {
        InitializeComponent();
    }


    private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
    {
    }

    private void CreateAuctionButton_Click(object sender, RoutedEventArgs e)
    {

        if (mainWindow == null)
        {
            mainWindow.ShowSetForSaleScreen();
            
        }
        

    }
}