using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class Auction
    {

        public Auction(Vehicle vehicle, ISeller seller, decimal minimumPrice)
        {
            Vehicle = vehicle;
            Seller = seller;
            MinimumPrice = minimumPrice;
        }
        /// <summary>
        /// ID of the auction
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The minimum price of the auction
        /// </summary>
        public decimal MinimumPrice { get; set; }
        /// <summary>
        /// The standing bid of the auction
        /// </summary>
        public decimal StandingBid { get; set; }
        /// <summary>
        /// The vehicle of the auction
        /// </summary>
        internal Vehicle Vehicle { get; set; }
        /// <summary>
        /// The seller of the auction
        /// </summary>
        internal ISeller Seller { get; set; }
        /// <summary>
        /// The buyer or potential buyer of the auction
        /// </summary>
        internal IBuyer Buyer { get; set; }

        public bool isDone { get; set; }


        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}