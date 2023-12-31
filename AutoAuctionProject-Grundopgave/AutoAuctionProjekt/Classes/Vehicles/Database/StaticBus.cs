﻿using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<Bus> Buses = new();

    public static Bus? GetBusById(int id)
    {
        return Buses.FirstOrDefault(bus => bus.BusID == id);
    }

    public static Bus? GetBusByVehicleId(int id)
    {
        return Buses.FirstOrDefault(bus => bus.VehicleID == id);
    }

    public static List<Bus> GetAllBuses()
    {
        return Buses;
    }
}