using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<Truck> Trucks = new();

    public static Truck? GetTruckById(int id)
    {
        return Trucks.FirstOrDefault(truck => truck.TruckID == id);
    }

    public static Truck? GetTruckByVehicleId(int id)
    {
        return Trucks.FirstOrDefault(truck => truck.VehicleID == id);
    }


    public static List<Truck> GetAllTrucks()
    {
        return Trucks;
    }
}