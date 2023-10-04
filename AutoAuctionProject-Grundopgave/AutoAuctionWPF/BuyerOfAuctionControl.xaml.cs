using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoAuctionWPF;

public partial class BuyerOfAuctionControl : UserControl
{
    private MainWindow mainWindow;

    private Auction auction;
    public BuyerOfAuctionControl(MainWindow main, Auction auction)
    {
        InitializeComponent();
        this.mainWindow = main;

        this.auction = auction;

        VehicleInfoPanel.DataContext = auction.Vehicle;

        Bus bus = Database.GetBusByVehicleId(auction.Vehicle.VehicleID);
        if (bus != null ) { BusPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = bus; }

        Truck truck = Database.GetTruckByVehicleId(auction.Vehicle.VehicleID);
        if (truck != null) { TruckPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = truck; }


        PrivatePersonalCar privatePersonalCar = Database.GetPrivatePersonalCarByVehicleId(auction.Vehicle.VehicleID);
        if (privatePersonalCar != null) { PriPerCarPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = privatePersonalCar; PriPerCarTrunk.Text = privatePersonalCar.TrunkDimentions.ToString(); }

        ProfessionalPersonalCar professionalPersonalCar = Database.GetProfessionalPersonalCarByVehicleId(auction.Vehicle.VehicleID);
        if (professionalPersonalCar != null) { ProPerCarPanel.Visibility = Visibility.Visible; VehicleTypeGrid.DataContext = professionalPersonalCar; ProPerCarTrunk.Text = professionalPersonalCar.TrunkDimentions.ToString(); }
    }
    private void PlaceBidButton_Click(object sender, RoutedEventArgs e)
    {
        
        decimal bidAmount = Convert.ToDecimal(BidAmount.Text);
        User user = Database.GetUserByUserName(Constants.Sql.User);
        if (AuctionHouse.RecieveBid(user,auction.ID, bidAmount))
        {
            DatabaseServer.InsertBidHistory(DateTime.Now, bidAmount, user.UserName, auction.ID);


            auction.StandingBid = bidAmount;
            AuctionInfoPanel.DataContext = auction;
            LatestBidTextBlock.Text = auction.StandingBid.ToString();

            mainWindow.ShowHomeScreen();
        }
        
    }
    private void Back_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowHomeScreen();
    }
}