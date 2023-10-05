using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<CorporateUser> CorporateUsers = new();

    public static CorporateUser? GetCorporateUserByUserName(string userName)
    {
        return CorporateUsers.FirstOrDefault(corporateUser => corporateUser.UserName == userName);
    }

    public static List<CorporateUser> GetAllCorporateUsers()
    {
        return CorporateUsers;
    }
}