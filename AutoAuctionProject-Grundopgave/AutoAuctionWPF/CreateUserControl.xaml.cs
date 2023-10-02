using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class CreateUserControl : UserControl
{
    private MainWindow mainWindow;

    public CreateUserControl(MainWindow mainWindow)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
    }

    private void CreateUserButton_Click(object sender, RoutedEventArgs e)
    {
        // Implementer brugeroprettelses logik her
        bool isUserCreated = true; // Placeholder for brugeroprettelse

        if (isUserCreated)
        {
            mainWindow.ShowLoginScreen();
        }
        else
        {
            MessageBox.Show("Unable to create user. Please try again.");
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}