using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Classes.Vehicles.Database
{
    public static partial class Database
    {
        public static readonly List<PrivatePersonalCar> PrivatePersonalCars = new();

        public static PrivatePersonalCar? GetPrivatePersonalCarById(int id)
        {
            return PrivatePersonalCars.FirstOrDefault(privatePersonalCar => privatePersonalCar.PrivatePersonalCarID == id);
        }
        public static PrivatePersonalCar? GetPrivatePersonalCarByVehicleId(int id)
        {
            return PrivatePersonalCars.FirstOrDefault(privatePersonalCar => privatePersonalCar.VehicleID == id);
        }
        public static List<PrivatePersonalCar> GetAllPrivatePersonalCars()
        {
            return PrivatePersonalCars;
        }
    }
}
