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

    public abstract class User : ISeller, IBuyer
    {
        protected User(string userName, bool isCorporate, decimal balance, string zipCode)
        {
            //TODO: U1 - Set constructor and field

            UserName = userName;
            IsCorporate = isCorporate;
            Balance = balance;
            Zipcode = zipCode;

            

        }
        /// <summary>
        /// ID proberty
        /// </summary>
        public uint ID { get; private set; }
        public string UserName { get; set; }
        public bool IsCorporate { get; set; }
        public decimal Balance { get; set; }
        public string Zipcode { get; set; }

        public string ReceiveBidNodification(string message)
        {
            return "";
        }



        /// <summary>
        /// Returns the User in a string with relivant information.
        /// </summary>
        /// <returns>...</returns>
        public override string ToString()
        {
            string desc = $"UserName: {this.UserName}, IsCorporate: {this.IsCorporate}, Balance: {this.Balance}, ZipCode: {this.Zipcode}";
            return desc;
        }
    }
}
