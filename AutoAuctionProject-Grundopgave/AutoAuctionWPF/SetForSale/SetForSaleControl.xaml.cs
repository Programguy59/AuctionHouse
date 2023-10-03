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

    private void ChoseVehicle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }


    private void ComboBoxItemBus_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Visible;
        PrivatePersonalCarControl.Visibility = Visibility.Collapsed;
        ProfessionalPersonalCarControl.Visibility = Visibility.Collapsed;
        TruckControl.Visibility = Visibility.Collapsed;
    }

    private void ComboBoxItemTruck_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Collapsed;
        ProfessionalPersonalCarControl.Visibility = Visibility.Collapsed;
        TruckControl.Visibility = Visibility.Visible;
    }

    private void ComboBoxItemProfessionalPersonalCar_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Collapsed;
        ProfessionalPersonalCarControl.Visibility = Visibility.Visible;
        TruckControl.Visibility = Visibility.Collapsed;
    }

    private void ComboBoxItemPrivatePersonalCar_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Visible;
        ProfessionalPersonalCarControl.Visibility = Visibility.Collapsed;
        TruckControl.Visibility = Visibility.Collapsed;
    }
}