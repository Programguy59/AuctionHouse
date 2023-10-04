using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class BuyerOfAuctionControl : UserControl
{
    private MainWindow mainWindow;
    public BuyerOfAuctionControl(MainWindow main, Auction auction)
    {
        InitializeComponent();
        this.mainWindow = main;

        VehicleInfoPanel.DataContext = auction.Vehicle;

        Bus bus = Database.GetBusByVehicleId(auction.Vehicle.VehicleID);
        if (bus != null ) { BusPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = bus; }

        Truck truck = Database.GetTruckByVehicleId(auction.Vehicle.VehicleID);
        if (truck != null) { TruckPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = truck; }


        PrivatePersonalCar privatePersonalCar = Database.GetPrivatePersonalCarByVehicleId(auction.Vehicle.VehicleID);
        if (privatePersonalCar != null) { PriPerCarPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = privatePersonalCar; PriPerCarTrunk.Text = privatePersonalCar.TrunkDimentions.ToString(); }

        ProfessionalPersonalCar professionalPersonalCar = Database.GetProfessionalPersonalCarByVehicleId(auction.Vehicle.VehicleID);
        if (professionalPersonalCar != null) { ProPerCarPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = professionalPersonalCar; ProPerCarTrunk.Text = professionalPersonalCar.TrunkDimentions.ToString(); }


        AuctionInfoPanel.DataContext = auction;
        LatestBidTextBlock.Text = auction.StandingBid.ToString();
    }

    private void PlaceBidButton_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}