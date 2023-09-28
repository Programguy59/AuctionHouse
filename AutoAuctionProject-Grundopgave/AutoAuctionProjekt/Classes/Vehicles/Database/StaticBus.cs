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
        public static readonly List<Bus> Buses = new();

        public static Bus? GetAddressById(int id)
        {
            return Buses.FirstOrDefault(bus => bus.Id == id);
        }

        public static List<Bus> GetAllAddresses()
        {
            return Buses;
        }
    }
}
