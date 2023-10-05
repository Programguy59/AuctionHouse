using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<ProfessionalPersonalCar> ProfessionalPersonalCars = new();

    public static ProfessionalPersonalCar? GetProfessionalPersonalCarById(int id)
    {
        return ProfessionalPersonalCars.FirstOrDefault(professionalPersonalCar =>
            professionalPersonalCar.ProfessionalPersonalCarID == id);
    }

    public static ProfessionalPersonalCar? GetProfessionalPersonalCarByVehicleId(int id)
    {
        return ProfessionalPersonalCars.FirstOrDefault(professionalPersonalCar =>
            professionalPersonalCar.VehicleID == id);
    }

    public static List<ProfessionalPersonalCar> GetAllProfessionalPersonalCars()
    {
        return ProfessionalPersonalCars;
    }
}