using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    class Truck : HeavyVehicle
    {
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
            double loadCapacity) : 
            base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            //TODO: V10 - Constructor for Truck, DriversLisence should be CE if the truck has a towbar, otherwise it should be C

            if (hasTowbar)
            {
                DriversLisence = DriversLisenceEnum.CE;
            } else
            {
                DriversLisence = DriversLisenceEnum.C;
            }

            EngineSize = engineSize;
            LoadCapacity = loadCapacity;


            //TODO: V11 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        /// <returns>The size the the engine as a double</returns>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                if (4.2 < value && value < 15.0)
                {
                    EngineSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                EngineSize = value;
            }
        }
        /// <summary>
        /// Load Capacity field and proberty
        /// </summary>
        public double LoadCapacity { get; set; }
        /// <summary>
        /// Returns the Truck in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            string description = base.ToString() + $"LoadCapacity: {this.LoadCapacity}";
            return description;
        }
    }
}
