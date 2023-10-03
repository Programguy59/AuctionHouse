using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class CorporateUser : User
    {
        public CorporateUser(string userName, bool isCorporate, decimal balance, string zipCode, uint cvrNummer, decimal credit) : base(userName, isCorporate, balance, zipCode)
        {
            CVRNumber = cvrNummer;
            Credit = credit;

            //TODO: U8 - Add to database and set ID
            throw new NotImplementedException();
        }
        public uint CVRNumber { get; set; }
        public decimal Credit { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", CVRNumber: {this.CVRNumber}, Credit: {this.Credit}";
        }

    }
}
