using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Util;
using AutoAuctionWPF.SetForSale;

namespace AutoAuctionWPF;

public partial class SetForSaleControl : UserControl
{
    private decimal _depth;
    private string _endDate;
    private double _engineSize;
    private Vehicle.FuelTypeEnum _fuelType;
    private bool _hasIsoFixFitting;
    private bool _hasSaftybar;
    private bool _hasToilet;
    private decimal _height;
    private double _kmPerLiter;
    private decimal _length;
    private decimal _loadCapacity;
    private double _mileage;
    private decimal _newPrice;
    private ushort _numberOfSeats;
    private ushort _numberOfSleepingSpaces;
    private string _registrationNumber;
    private decimal _startBid;
    private bool _towbar;
    private string _vehicleName;
    private decimal _weight;
    private ushort _year;
    private string IsSelcted = "";
    private readonly MainWindow mainWindow;


    public SetForSaleControl(MainWindow main)
    {
        InitializeComponent();
        mainWindow = main;
    }

    private void SetForSaleButton_Click(object sender, RoutedEventArgs e)
    {
        _fuelType = SetForSaleBus._fuelType;
        _vehicleName = NameTextBox.Text;
        _mileage = Convert.ToDouble(MileageTextBox.Text);
        _registrationNumber = RegistrationNumberTextBox.Text;
        _year = Convert.ToUInt16(YearTextBox.Text);
        _startBid = Convert.ToDecimal(StartBidTextBox.Text);
        _endDate = EndDatePicker.Text;
        _newPrice = Convert.ToDecimal(NewPriceTextBox.Text);

        if (IsSelcted == "Bus")
        {
            _height = SetForSaleBus._height;
            _length = SetForSaleBus._length;
            _weight = SetForSaleBus._weight;
            _engineSize = SetForSaleBus._engineSize;
            _numberOfSeats = SetForSaleBus._numberOfSeats;
            _numberOfSleepingSpaces = SetForSaleBus._numberOfSleepingSpaces;
            _hasToilet = SetForSaleBus._hasToilet;
            _kmPerLiter = SetForSaleBus._kmPerLiter;
            _fuelType = SetForSaleBus._fuelType;
            _towbar = SetForSaleBus._towbar;
            _hasToilet = SetForSaleBus._hasToilet;
            try
            {
                new Bus(_vehicleName, _mileage, _registrationNumber, _year, _newPrice, _towbar, _engineSize,
                    _kmPerLiter, _fuelType,
                    new HeavyVehicle.VehicleDimensionsStruct(_height, _weight, _length), _numberOfSeats,
                    _numberOfSleepingSpaces, _hasToilet);
                AuctionHouse.SetForSale(Database.Buses.Last(), Database.GetUserByUserName(Constants.Sql.User),
                    _startBid);
            }
            catch (Exception exception)
            {
                Console.WriteLine("something went wrong");
            }
        }

        if (IsSelcted == "Truck")
        {
            _height = SetForSaleTruck._height;
            _length = SetForSaleTruck._length;
            _weight = SetForSaleTruck._weight;
            _engineSize = SetForSaleTruck._engineSize;
            _loadCapacity = SetForSaleTruck._loadCapacity;
            _kmPerLiter = SetForSaleTruck._kmPerLiter;
            _fuelType = SetForSaleTruck._fuelType;
            _towbar = SetForSaleTruck._towbar;

            MessageBox.Show(_engineSize.ToString());
            try
            {
                new Truck(_vehicleName, _mileage, _registrationNumber, _year, _newPrice, _towbar, _engineSize,
                    _kmPerLiter, _fuelType,
                    new HeavyVehicle.VehicleDimensionsStruct(_height, _weight, _length), _loadCapacity);
                AuctionHouse.SetForSale(Database.Trucks.Last(), Database.GetUserByUserName(Constants.Sql.User),
                    _startBid);
            }
            catch (Exception exception)
            {
                Console.WriteLine("something went wrong");
                throw;
            }
        }

        {
        }

        if (IsSelcted == "ProfessionalPersonalCar")
        {
            _hasSaftybar = SetForSaleProfessionalPersonalCar._hasSaftybar;
            _loadCapacity = SetForSaleProfessionalPersonalCar._loadCapacity;
            _height = SetForSaleProfessionalPersonalCar._height;
            _weight = SetForSaleProfessionalPersonalCar._weight;
            _depth = SetForSaleProfessionalPersonalCar._depth;
            _engineSize = SetForSaleProfessionalPersonalCar._engineSize;
            _numberOfSeats = SetForSaleProfessionalPersonalCar._numberOfSeats;
            _kmPerLiter = SetForSaleProfessionalPersonalCar._kmPerLiter;
            _fuelType = SetForSaleProfessionalPersonalCar._fuelType;

            try
            {
                new ProfessionalPersonalCar(_vehicleName, _mileage, _registrationNumber, _year,
                    _startBid, _engineSize, _kmPerLiter, _fuelType, _numberOfSeats,
                    new PersonalCar.TrunkDimentionsStruct(_height, _weight, _depth), _hasSaftybar, _loadCapacity);

                AuctionHouse.SetForSale(Database.ProfessionalPersonalCars.Last(),
                    Database.GetUserByUserName(Constants.Sql.User), _startBid);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }


            AuctionHouse.SetForSale(Database.ProfessionalPersonalCars.Last(),
                Database.GetUserByUserName(Constants.Sql.User), _startBid);
        }

        if (IsSelcted == "PrivatePersonalCar")
        {
            _towbar = SetForSalePrivatePersonalCar._towbar;
            _height = SetForSalePrivatePersonalCar._height;
            _weight = SetForSalePrivatePersonalCar._weight;
            _depth = SetForSalePrivatePersonalCar._depth;
            _engineSize = SetForSalePrivatePersonalCar._engineSize;
            _numberOfSeats = SetForSalePrivatePersonalCar._numberOfSeats;
            _kmPerLiter = SetForSalePrivatePersonalCar._kmPerLiter;
            _fuelType = SetForSalePrivatePersonalCar._fuelType;
            _hasIsoFixFitting = SetForSalePrivatePersonalCar._hasIsoFixFitting;

            new PrivatePersonalCar(_vehicleName, _mileage, _registrationNumber, _year,
                _newPrice, _towbar, _engineSize, _kmPerLiter, _fuelType, _numberOfSeats,
                new PersonalCar.TrunkDimentionsStruct(_height, _weight, _depth), _hasIsoFixFitting);

            AuctionHouse.SetForSale(Database.PrivatePersonalCars.Last(),
                Database.GetUserByUserName(Constants.Sql.User), _startBid);
        }

        mainWindow.ShowHomeScreen();
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
        IsSelcted = "Bus";
    }

    private void ComboBoxItemTruck_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Collapsed;
        ProfessionalPersonalCarControl.Visibility = Visibility.Collapsed;
        TruckControl.Visibility = Visibility.Visible;
        IsSelcted = "Truck";
    }

    private void ComboBoxItemProfessionalPersonalCar_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Collapsed;
        ProfessionalPersonalCarControl.Visibility = Visibility.Visible;
        TruckControl.Visibility = Visibility.Collapsed;
        IsSelcted = "ProfessionalPersonalCar";
    }

    private void ComboBoxItemPrivatePersonalCar_OnSelected(object sender, RoutedEventArgs e)
    {
        BusControl.Visibility = Visibility.Collapsed;
        PrivatePersonalCarControl.Visibility = Visibility.Visible;
        ProfessionalPersonalCarControl.Visibility = Visibility.Collapsed;
        TruckControl.Visibility = Visibility.Collapsed;
        IsSelcted = "PrivatePersonalCar";
    }

    private void Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        mainWindow.ShowHomeScreen();
    }
}