using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<PrivateUser> PrivateUsers = new();

    public static PrivateUser? GetPrivateUserByUserName(string userName)
    {
        return PrivateUsers.FirstOrDefault(PrivateUser => PrivateUser.UserName == userName);
    }

    public static List<PrivateUser> GetAllPrivateUsers()
    {
        return PrivateUsers;
    }
}