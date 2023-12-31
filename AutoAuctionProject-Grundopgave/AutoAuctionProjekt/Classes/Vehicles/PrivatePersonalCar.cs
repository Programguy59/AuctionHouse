﻿using AutoAuctionProjekt.Util;

namespace AutoAuctionProjekt.Classes;

public class PrivatePersonalCar : PersonalCar
{
    //Constructor for creating PrivatePersonalCar from database
    public PrivatePersonalCar(
        string name,
        double km,
        string registrationNumber,
        ushort year,
        decimal newPrice,
        bool hasTowbar,
        double engineSize,
        double kmPerLiter,
        FuelTypeEnum fuelType,
        ushort numberOfSeat,
        TrunkDimentionsStruct trunkDimentions,
        bool hasIsofixFittings,
        int vehicleId,
        int personalCarId,
        int privatePersonalCarId
    )
        : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeat,
            trunkDimentions)
    {
        HasIsofixFittings = hasIsofixFittings;

        VehicleID = vehicleId;
        PersonalCarID = personalCarId;
        PrivatePersonalCarID = privatePersonalCarId;
    }

    //Constructor for creating PrivatePersonalCar from program
    public PrivatePersonalCar(
        string name,
        double km,
        string registrationNumber,
        ushort year,
        decimal newPrice,
        bool hasTowbar,
        double engineSize,
        double kmPerLiter,
        FuelTypeEnum fuelType,
        ushort numberOfSeat,
        TrunkDimentionsStruct trunkDimentions,
        bool hasIsofixFittings)
        : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeat,
            trunkDimentions)
    {
        DriversLisence = DriversLisenceEnum.B;

        HasIsofixFittings = hasIsofixFittings;


        DatabaseServer.InsertPrivatePersonalCar(this);
    }


    public override DriversLisenceEnum DriversLisence { get; set; }

    public int PrivatePersonalCarID { get; set; }


    /// <summary>
    ///     Isofix Fittings proberty
    /// </summary>
    public bool HasIsofixFittings { get; set; }

    /// <summary>
    ///     Returns the PrivatePersonalCar in a string with relivant information.
    /// </summary>
    public override string ToString()
    {
        var desc = base.ToString() + $"HasIsofixFittings: {HasIsofixFittings} ";
        return desc;
    }
}