using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, bool isCorporate, decimal balance, string zipCode, string cprNummer) : base(userName, isCorporate, balance, zipCode)
        {
            //TODO: U10 - Set constructor
               
            CPRNumber = cprNummer;
            
            //TODO: U11 - Add to database and set ID
        }
        public string CPRNumber { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", CPRNumber: {this.CPRNumber}";
        }

    }

}
