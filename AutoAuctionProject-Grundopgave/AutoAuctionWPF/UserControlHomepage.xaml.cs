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
    }


    private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowUserProfileScreen();
    }

    private void CreateAuctionButton_Click(object sender, RoutedEventArgs e)
    {

        
            mainWindow.ShowSetForSaleScreen();
        

    }
}