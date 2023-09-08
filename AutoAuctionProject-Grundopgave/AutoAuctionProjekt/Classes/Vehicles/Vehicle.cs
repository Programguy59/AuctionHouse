using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public abstract class Vehicle
    {
        protected Vehicle(string name,
            double km,
            string registrationNumber,
            int year,
            decimal newPrice,
            bool hasTowbar,
            double engineSize,
            double kmPerLiter,
            FuelTypeEnum fuelType)
        {
            this.Name = name;
            this.Km = km;
            this.RegistrationNumber = registrationNumber;
            this.Year = year;
            this.NewPrice = newPrice;
            this.HasTowbar = hasTowbar;
            this.EngineSize = engineSize;
            this.KmPerLiter = kmPerLiter;
            this.FuelType = fuelType;
            //TODO: V2 - Add to database and set ID
        }
        /// <summary>
        /// ID field and proberty
        /// </summary>
        public uint ID { get; private set; }
        /// <summary>
        /// Name field and proberty
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Km field and proberty
        /// </summary>
        public double Km { get; set; }
        /// <summary>
        /// Registration number field and proberty
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Year field and proberty
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// New price field and proberty
        /// </summary>
        public decimal NewPrice { get; set; }
        /// <summary>
        /// Towbar field and proberty
        /// </summary>
        public bool HasTowbar { get; set; }
        /// <summary>
        /// Engine size field and proberty
        /// </summary>
        public virtual double EngineSize { get; set; }
        /// <summary>
        /// Km per liter field and proberty
        /// </summary>
        public double KmPerLiter { get; set; }
        /// <summary>
        /// Drivers lisence Enum, field and proberty
        /// </summary>
        public virtual DriversLisenceEnum DriversLisence { get; set; }
        public enum DriversLisenceEnum
        {
            A,
            B,
            C,
            D,
            BE,
            CE,
            DE
        }
        /// <summary>
        /// NFuel type Enum, field and proberty
        /// </summary>
        public FuelTypeEnum FuelType { get; set; }
        public enum FuelTypeEnum
        {
            Diesel,
            Benzin
        }
        /// <summary>
        /// Engery class Enum, field and proberty
        /// </summary>
        public EnergyClassEnum EnergyClass { get { return EnergyClass; } set => GetEnergyClass(); }
        public enum EnergyClassEnum
        {
            A,
            B,
            C,
            D
        }
        /// <summary>
        /// Engery class is calculated bassed on year of the car and the efficiancy in km/L.
        /// </summary>
        /// <returns>
        /// Returns the energy class in EnergyClassEnum (A,B,C,D)
        /// </returns>
        private EnergyClassEnum GetEnergyClass()
        {
            if (Year > 2010)
            {
                if (FuelType == FuelTypeEnum.Diesel)
                {
                    switch (KmPerLiter )
                    {
                        case var kmPerLiter when (kmPerLiter >= 25):
                            return EnergyClassEnum.A;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 25 && kmPerLiter >= 20):
                            return EnergyClassEnum.B;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 20 && kmPerLiter >= 15):
                            return EnergyClassEnum.C;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 15):
                            return EnergyClassEnum.D;
                            break;
                    }
                }
                else if (FuelType == FuelTypeEnum.Benzin)
                {
                    switch (KmPerLiter )
                    {
                        case var kmPerLiter when (kmPerLiter >= 20 ):
                            return EnergyClassEnum.A;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 20 && kmPerLiter >= 16):
                            return EnergyClassEnum.B;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 16 && kmPerLiter >= 12):
                            return EnergyClassEnum.C;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 12):
                            return EnergyClassEnum.D;
                            break;
                    }   
                }
            }
            
            if (Year < 2010 )
                if (FuelType == FuelTypeEnum.Diesel)
                {
                    switch (KmPerLiter )
                    {
                        case var kmPerLiter when (kmPerLiter >= 23):
                            return EnergyClassEnum.A;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 23 && kmPerLiter >= 18):
                            return EnergyClassEnum.B;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 18 && kmPerLiter >= 13):
                            return EnergyClassEnum.C;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 13):
                            return EnergyClassEnum.D;
                            break;
                    }
                }
                else if (FuelType == FuelTypeEnum.Diesel)
                {
                    switch (KmPerLiter )
                    {
                        case var kmPerLiter when (kmPerLiter >= 18):
                            return EnergyClassEnum.A;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 18 && kmPerLiter >= 14):
                            return EnergyClassEnum.B;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 14 && kmPerLiter >= 10):
                            return EnergyClassEnum.C;
                            break;
                    
                        case var kmPerLiter when (kmPerLiter < 10):
                            return EnergyClassEnum.D;
                            break;
                    }   
                }
            
            return EnergyClassEnum.A;
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns the vehicle in a string with relivant information.
        /// </summary>
        /// <returns>The Veihcle as a string</returns>
        public new virtual string ToString()
        {
            string desc = $"The {this.Name} is from {this.Year} Regisration number is {this.RegistrationNumber}. it has driven {this.Km} when new it cost {this.NewPrice}. The engine is {this.EngineSize} liters  and does {this.KmPerLiter} km per liter on {this.FuelType} ";
            return desc;
        }
    }
}
