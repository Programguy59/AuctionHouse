using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    class Bus : HeavyVehicle
    {
        public Bus (
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
            bool hasToilet) : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType, vehicleDimentions)
        {
            this.NumberOfSeats = numberOfSeats;
            this.NumberOfSleepingSpaces = numberOfSleepingSpaces;
            this.HasToilet = hasToilet;
            //TODO: V7 - set contructor and DriversLisence to DE if the car has a towbar or D if not.
            //TODO: V8 - Add to database and set ID
            throw new NotImplementedException();
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 4.2 and 15.0 L or cast an out of range exection.
        /// </summary>
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
            }
        }
        public override DriversLisenceEnum DriversLisence {
            get { return DriversLisence; }

            set{
                if (DriversLisence == DriversLisenceEnum.D || DriversLisence == DriversLisenceEnum.DE)
                {
                    DriversLisence = value;
                }
                else { throw new ArgumentOutOfRangeException("value"); }        
            } }


        /// <summary>
        /// NumberOfSeats proberty
        /// </summary>
        public ushort NumberOfSeats { get; set; }
        /// <summary>
        /// NumberOfSeats proberty
        /// </summary>
        public ushort NumberOfSleepingSpaces { get; set; }
        /// Towbar proberty
        /// </summary>
        public bool HasToilet { get; set; }
        /// <summary>
        /// Returns the Bus in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            string desc = $"The {this.Name} is from {this.Year} Regisration number is {this.RegistrationNumber}. The height of the vehicle is {this.VehicleDimensions.Height}" +
                $" the length is {this.VehicleDimensions.Length} it weights {this.VehicleDimensions.Weight} there are {this.NumberOfSeats} seats and {NumberOfSleepingSpaces} Sleeping spaces," +
                $" does it have a toilet? {this.HasToilet},it has driven {this.Km} when new it cost {this.NewPrice}. The engine is {this.EngineSize} liters  and does {this.KmPerLiter} " +
                $"km per liter on {this.FuelType} ";
            return desc;
        }
    }
}
