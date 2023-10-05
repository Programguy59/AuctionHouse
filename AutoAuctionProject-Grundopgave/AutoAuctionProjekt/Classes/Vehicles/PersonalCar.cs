using System;

namespace AutoAuctionProjekt.Classes;

public abstract class PersonalCar : Vehicle
{
    /// <summary>
    ///     Engine size proberty
    ///     must be between 0.7 and 10.0 L or cast an out of range exection.
    /// </summary>
    private double _EngineSize;

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
        NumberOfSeat = numberOfSeat;
        TrunkDimentions = trunkDimentions;
    }

    /// <summary>
    ///     Number of seat proberty
    /// </summary>
    public ushort NumberOfSeat { get; set; }

    public int PersonalCarID { get; set; }

    /// <summary>
    ///     Trunk dimentions proberty and struct
    /// </summary>
    public TrunkDimentionsStruct TrunkDimentions { get; set; }

    public override double EngineSize
    {
        get => _EngineSize;
        set
        {
            if (0.7 < value && value < 10.0)
                _EngineSize = value;
            else
                throw new ArgumentOutOfRangeException("value");
        }
    }

    public override DriversLisenceEnum DriversLisence
    {
        get => DriversLisence;
        set
        {
            if (DriversLisence == DriversLisenceEnum.B || DriversLisence == DriversLisenceEnum.BE)
                DriversLisence = value;
            else
                throw new ArgumentOutOfRangeException("value");
        }
    }

    /// <summary>
    ///     Returns the PersonalCar in a string with relivant information.
    /// </summary>
    public override string ToString()
    {
        var desc = base.ToString() + $"NumberOfSeat: {NumberOfSeat}, TrunkDimentions: {TrunkDimentions.ToString} ";
        return desc;
    }

    public struct TrunkDimentionsStruct
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

        public override string ToString()
        {
            return $"Height: {Height}, Width: {Width}, Depth: {Depth}";
        }
    }
}