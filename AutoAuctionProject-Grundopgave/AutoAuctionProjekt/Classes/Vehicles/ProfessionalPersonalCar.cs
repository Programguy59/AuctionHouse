using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class ProfessionalPersonalCar : PersonalCar
    {
        //Constructor for creating ProfessionalPersonalCar from database
        public ProfessionalPersonalCar(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            ushort numberOfSeat,
            TrunkDimentionsStruct trunkDimentions,
            bool hasSafetyBar,
            decimal loadCapacity,
            int vehicleId,
            int personalCarId,
            int professionalPersonalCarId)
            : base(name, km, registrationNumber, year, newPrice, true, engineSize, kmPerLiter, fuelType, numberOfSeat, trunkDimentions)
        {

            HasSafetyBar = hasSafetyBar;
            LoadCapacity = loadCapacity;

            VehicleID = vehicleId;
            PersonalCarID = personalCarId;
            ProfessionalPersonalCarID = professionalPersonalCarId;


            if (loadCapacity < 750)
            {
                DriversLisence = DriversLisenceEnum.B;
            }
            else
            {
                DriversLisence = DriversLisenceEnum.BE;
            }

        }
        //Constructor for creating ProfessionalPersonalCar from program
        public ProfessionalPersonalCar(
            string name,
            double km,
            string registrationNumber,
            ushort year,
            decimal newPrice,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType,
            ushort numberOfSeat,
            TrunkDimentionsStruct trunkDimentions,
            bool hasSafetyBar,
            decimal loadCapacity)
            : base(name, km, registrationNumber, year, newPrice, true, engineSize, kmPerLiter, fuelType, numberOfSeat, trunkDimentions)
        {

            HasSafetyBar = hasSafetyBar;
            LoadCapacity = loadCapacity;

            if (loadCapacity < 750)
            {
                DriversLisence = DriversLisenceEnum.B;
            }
            else
            {
                DriversLisence = DriversLisenceEnum.BE;
            }

            //TODO: V17 - Add to database and set ID
        }

        public int ProfessionalPersonalCarID { get; set; }


        /// <summary>
        /// Safety Bar proberty
        /// </summary>
        public bool HasSafetyBar { get; set; }
        /// <summary>
        /// Load Capacity proberty
        /// </summary>
        public decimal LoadCapacity { get; set; }
        /// <summary>
        /// Returns the ProfessionalPersonalCar in a string with relivant information.
        /// </summary>
        /// <returns>The Veihcle as a string</returns>
        public override string ToString()
        {
            string description = base.ToString() + $"LoadCapacity: {this.LoadCapacity} HasSafetyBar: {this.HasSafetyBar}";
            return description;
        }
    }
}
