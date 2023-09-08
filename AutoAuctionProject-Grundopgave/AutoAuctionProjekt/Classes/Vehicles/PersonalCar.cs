using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public abstract class PersonalCar : Vehicle
    {
        protected PersonalCar(
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
            TrunkDimentionsStruct trunkDimentions)
            : base(name, km, registrationNumber, year, newPrice, hasTowbar, engineSize, kmPerLiter, fuelType)
        {
            this.NumberOfSeat = numberOfSeat;
            this.TrunkDimentions = trunkDimentions;
        }
        /// <summary>
        /// Number of seat proberty
        /// </summary>
        public ushort NumberOfSeat { get; set; }
        /// <summary>
        /// Trunk dimentions proberty and struct
        /// </summary>
        public TrunkDimentionsStruct TrunkDimentions { get; set; }
        public readonly struct TrunkDimentionsStruct
        {
            public TrunkDimentionsStruct(double height, double width, double depth)
            {
                Height = height;
                Width = width;
                Depth = depth;
            }
            public double Height { get; }
            public double Width { get; }
            public double Depth { get; }
            public override string ToString() => $"(Height: {Height}, Width: {Width}, Depth: {Depth})";
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 0.7 and 10.0 L or cast an out of range exection.
        /// </summary>
        public override double EngineSize
        {
            get { return EngineSize; }
            set
            {
                //TODO: V13 - EngineSize: must be between 0.7 and 10.0 L or cast an out of range exection.
                if (0.7 < value && value < 10.0)
                {
                    EngineSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }

            }
        }

        public override DriversLisenceEnum DriversLisence
        {
            get { return DriversLisence; }
            set 
            {
                if (DriversLisence == DriversLisenceEnum.B || DriversLisence == DriversLisenceEnum.BE)
                {
                    DriversLisence = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        /// <summary>
        /// Returns the PersonalCar in a string with relivant information.
        /// </summary>
        public override string ToString()
        {
            string desc = base.ToString() + $"It has {this.NumberOfSeat} seats, and the trunk has the dimensions {this.TrunkDimentions.ToString}";
            return desc;
        }
    }
}