using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivatePersonalCar : PersonalCar
    {
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
            : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, numberOfSeat, trunkDimentions)
        {


            HasIsofixFittings = hasIsofixFittings;


            //TODO: V20 - Add to database and set ID
        }
        /// <summary>
        /// Isofix Fittings proberty
        /// </summary>
        public bool HasIsofixFittings { get; set; }
        /// <summary>
        /// Returns the PrivatePersonalCar in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            string desc = base.ToString() + $"HasIsofixFittings: {HasIsofixFittings} ";
            return desc;
        }
    }
}
