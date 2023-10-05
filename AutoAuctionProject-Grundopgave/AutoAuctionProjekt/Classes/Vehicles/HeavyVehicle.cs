namespace AutoAuctionProjekt.Classes;

public abstract class HeavyVehicle : Vehicle
{
    public HeavyVehicle(
        string name,
        double km,
        string registrationNumber,
        ushort year,
        decimal newPrice,
        bool hasTowbar,
        double engineSize,
        double kmPerLiter,
        FuelTypeEnum fuelType,
        VehicleDimensionsStruct vehicleDimentions) : base(name, km, registrationNumber, year, newPrice, hasTowbar,
        engineSize, kmPerLiter, fuelType)
    {
        VehicleDimensions = vehicleDimentions;
    }

    public int HeavyVehicleID { get; set; }


    /// <summary>
    ///     Vehicle dimentions proberty and struct
    /// </summary>
    public VehicleDimensionsStruct VehicleDimensions { get; set; }

    /// <summary>
    ///     Returns the HeavyVehicle in a string with relivant information.
    /// </summary>
    public override string ToString()
    {
        var desc = base.ToString() +
                   $"(Height: {VehicleDimensions.Height}, Weight: {VehicleDimensions.Weight}, length: {VehicleDimensions.Length}) ";
        return desc;
    }

    /// <summary>
    ///     The dimensions of the vehicle i meters.
    /// </summary>
    public struct VehicleDimensionsStruct
    {
        public VehicleDimensionsStruct(decimal height, decimal weight, decimal length)
        {
            Height = height;
            Weight = weight;
            Length = length;
        }

        public decimal Height { get; }
        public decimal Weight { get; }
        public decimal Length { get; }

        public override string ToString()
        {
            return $"(Height: {Height}, Weight: {Weight}, length: {Length})";
        }
    }
}