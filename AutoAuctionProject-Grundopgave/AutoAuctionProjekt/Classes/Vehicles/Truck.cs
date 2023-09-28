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
            decimal loadCapacity) : 
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
    
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
        /// <returns>The size the the engine as a double</returns>
        double _EngineSize;
        public override double EngineSize
        {
            get { return _EngineSize; }
            set
            {
                if (4.2 < value && value < 15.0)
                {
                    _EngineSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                _EngineSize = value;
            }
        }
        /// <summary>
        /// Load Capacity field and proberty
        /// </summary>
        public Decimal LoadCapacity { get; set; }
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
