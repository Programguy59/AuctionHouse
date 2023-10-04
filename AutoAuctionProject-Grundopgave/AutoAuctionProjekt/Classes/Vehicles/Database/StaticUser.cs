﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Classes.Vehicles.Database
{
    public static partial class Database
    {
        public static readonly List<User> Users = new();

        public static User? GetUserByUserName(string UserName)
        {
            foreach (var corpUser in Database.CorporateUsers)
            {
                User user = corpUser;
                if (!Users.Contains(user))
                {
                    Users.Add(user);
                }
            }
            foreach (var PrivteUser in Database.PrivateUsers)
            {
                User user = PrivteUser;
                if (!Users.Contains(user))
                {
                    Users.Add(user);
                }
            }
            return Users.FirstOrDefault(user => user.UserName == UserName);
        }

        public static List<User> GetAllUsers()
        {
            return Users;
        }
    }
}
