using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class CorporateUser : User
    {
        public CorporateUser(string userName, bool isCorporate, decimal balance, string zipCode, string cvrNummer, decimal credit) : base(userName, isCorporate, balance, zipCode)
        {
            CVRNumber = cvrNummer;
            Credit = credit;

        }
        public string CVRNumber { get; set; }
        public decimal Credit { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", CVRNumber: {this.CVRNumber}, Credit: {this.Credit}";
        }

    }
}
