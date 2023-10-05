using System;
using AutoAuctionProjekt.Util;

namespace AutoAuctionProjekt.Classes;

public class Truck : HeavyVehicle
{
    /// <summary>
    ///     Engine size proberty
    ///     must be between 4.2 and 15.0 L or cast an out of range exection.
    /// </summary>
    /// <returns>The size the the engine as a double</returns>
    private double _EngineSize;

    //Create truck from database
    public Truck(
        string name,
        double km,
        string registrationNumber,
        ushort year,
        decimal newPrice,
        bool hasTowbar,
        double engineSize,
        double kmPerLiter,
        FuelTypeEnum fuelType,
        VehicleDimensionsStruct vehicleDimentions,
        decimal loadCapacity,
        int vehicleID,
        int heavyVehicleID,
        int truckID
    ) :
        base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType,
            vehicleDimentions)
    {
        //TODO: V10 - Constructor for Truck, DriversLisence should be CE if the truck has a towbar, otherwise it should be C

        if (hasTowbar)
            DriversLisence = DriversLisenceEnum.CE;
        else
            DriversLisence = DriversLisenceEnum.C;

        EngineSize = engineSize;
        LoadCapacity = loadCapacity;
        VehicleID = vehicleID;
        HeavyVehicleID = heavyVehicleID;
        TruckID = truckID;
    }

    //Create truck from program
    public Truck(
        string name,
        double km,
        string registrationNumber,
        ushort year,
        decimal newPrice,
        bool hasTowbar,
        double engineSize,
        double kmPerLiter,
        FuelTypeEnum fuelType,
        VehicleDimensionsStruct vehicleDimentions,
        decimal loadCapacity) :
        base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType,
            vehicleDimentions)
    {
        //TODO: V10 - Constructor for Truck, DriversLisence should be CE if the truck has a towbar, otherwise it should be C

        if (hasTowbar)
            DriversLisence = DriversLisenceEnum.CE;
        else
            DriversLisence = DriversLisenceEnum.C;

        EngineSize = engineSize;
        LoadCapacity = loadCapacity;


        DatabaseServer.InsertTruck(this);
    }


    public override DriversLisenceEnum DriversLisence { get; set; }

    public override double EngineSize
    {
        get => _EngineSize;
        set
        {
            if (4.2 < value && value < 15.0)
                _EngineSize = value;
            else
                throw new ArgumentOutOfRangeException("value");

            _EngineSize = value;
        }
    }

    /// <summary>
    ///     Load Capacity field and proberty
    /// </summary>
    public decimal LoadCapacity { get; set; }

    public int TruckID { get; set; }

    /// <summary>
    ///     Returns the Truck in a string with relivant information.
    /// </summary>
    public override string ToString()
    {
        var description = base.ToString() + $"LoadCapacity: {LoadCapacity}";
        return description;
    }
}