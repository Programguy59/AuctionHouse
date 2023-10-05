using System;
using AutoAuctionProjekt.Util;

namespace AutoAuctionProjekt.Classes;

public class Bus : HeavyVehicle
{
    /// <summary>
    ///     Engine size proberty
    ///     must be between 4.2 and 15.0 L or cast an out of range exection.
    /// </summary>
    private double _EngineSize;

    //Constructor for creating bus from database
    public Bus(
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
        ushort numberOfSeats,
        ushort numberOfSleepingSpaces,
        bool hasToilet,
        int vehicleId,
        int heavyVechicleId,
        int busId
    ) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType,
        vehicleDimentions)
    {
        NumberOfSeats = numberOfSeats;
        NumberOfSleepingSpaces = numberOfSleepingSpaces;
        HasToilet = hasToilet;

        VehicleID = vehicleId;
        HeavyVehicleID = heavyVechicleId;
        BusID = busId;


        if (hasTowbar)
            DriversLisence = DriversLisenceEnum.DE;
        else
            DriversLisence = DriversLisenceEnum.D;

        //TODO: V8 - Add to database and set ID
    }

    //Constructor for creating Bus from program
    public Bus(
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
        ushort numberOfSeats,
        ushort numberOfSleepingSpaces,
        bool hasToilet) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter,
        fuelType, vehicleDimentions)
    {
        NumberOfSeats = numberOfSeats;
        NumberOfSleepingSpaces = numberOfSleepingSpaces;
        HasToilet = hasToilet;

        if (hasTowbar)
            DriversLisence = DriversLisenceEnum.DE;
        else
            DriversLisence = DriversLisenceEnum.D;

        //TODO: V8 - Add to database and set ID

        DatabaseServer.InsertBus(this);
    }

    public override double EngineSize
    {
        get => _EngineSize;
        set
        {
            if (4.2 < value && value < 15.0)
                _EngineSize = value;
            else
                throw new ArgumentOutOfRangeException("value");
        }
    }

    public override DriversLisenceEnum DriversLisence { get; set; }


    /// <summary>
    ///     NumberOfSeats proberty
    /// </summary>
    public ushort NumberOfSeats { get; set; }

    /// <summary>
    ///     NumberOfSeats proberty
    /// </summary>
    public ushort NumberOfSleepingSpaces { get; set; }

    /// Towbar proberty
    /// </summary>
    public bool HasToilet { get; set; }

    public int BusID { get; set; }

    /// <summary>
    ///     Returns the Bus in a string with relivant information.
    /// </summary>
    public override string ToString()
    {
        var desc = base.ToString() +
                   $"Number of seats {NumberOfSeats}, number of sleeping spaces {NumberOfSleepingSpaces}, has toilet{HasToilet}";
        return desc;
    }
}