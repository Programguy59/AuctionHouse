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
            public TrunkDimentionsStruct(decimal height, decimal width, decimal depth)
            {
                Height = height;
                Width = width;
                Depth = depth;
            }
            public decimal Height { get; }
            public decimal Width { get; }
            public decimal Depth { get; }
            public override string ToString() => $"(Height: {Height}, Width: {Width}, Depth: {Depth})";
        }
        /// <summary>
        /// Engine size proberty
        /// must be between 0.7 and 10.0 L or cast an out of range exection.
        /// </summary>
        private double _EngineSize;
        public override double EngineSize
        {
            get { return _EngineSize; }
            set
            {
                if (0.7 < value && value < 10.0)
                {
                    _EngineSize = value;
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
            string desc = base.ToString() + $"NumberOfSeat: {this.NumberOfSeat}, TrunkDimentions: {this.TrunkDimentions.ToString} ";
            return desc;
        }
    }
}