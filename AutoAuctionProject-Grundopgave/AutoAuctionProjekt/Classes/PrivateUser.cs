using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class PrivateUser : User
    {
        public PrivateUser(string userName, bool isCorporate, double balance, uint zipCode, uint cprNummer) : base(userName, isCorporate, balance, zipCode)
        {
            //TODO: U10 - Set constructor
               
            CPRNumber = cprNummer;
            
            //TODO: U11 - Add to database and set ID
        }
        public uint CPRNumber { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", CPRNumber: {this.CPRNumber}";
        }

    }

}
