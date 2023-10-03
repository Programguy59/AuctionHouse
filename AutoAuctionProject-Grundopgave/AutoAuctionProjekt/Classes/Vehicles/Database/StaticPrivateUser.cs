using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Classes.Vehicles.Database
{
    public static partial class Database
    {
        public static readonly List<PrivateUser> privateUsers = new();
        
        public static PrivateUser? GetPrivateUserById(string userName)
        {
            return privateUsers.FirstOrDefault(PrivateUser => PrivateUser.UserName == userName);
        }
        public static List<PrivateUser> GetAllPrivateUsers()
        {
            return privateUsers;
        }
    }
}
