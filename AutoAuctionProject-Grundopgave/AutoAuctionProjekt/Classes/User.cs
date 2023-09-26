using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace AutoAuctionProjekt.Classes
{
/*
 * Domæne model
interface polymorfi via interface
interface til at kunne køde og sælge til

køber og sælger som interfaces

privat og company som klasser
 */

    public abstract class User //TODO: U4 - Implement interfaces
    {
        protected User(string userName, bool isCorporate, double balance, uint zipCode)
        {
            //TODO: U1 - Set constructor and field

            UserName = userName;
            IsCorporate = isCorporate;
            Balance = balance;
            ZipCode = zipCode;

            

        }
        /// <summary>
        /// ID proberty
        /// </summary>
        public uint ID { get; private set; }
        public string UserName { get; set; }
        public bool IsCorporate { get; set; }
        public double Balance { get; set; }
        public uint ZipCode { get; set; }

        //TODO: U4 - Implement interface proberties and methods.

        /// <summary>
        /// Returns the User in a string with relivant information.
        /// </summary>
        /// <returns>...</returns>
        public override string ToString()
        {
            string desc = $"UserName: {this.UserName}, IsCorporate: {this.IsCorporate}, Balance: {this.Balance}, ZipCode: {this.ZipCode}";
            return desc;
        }
    }
}
