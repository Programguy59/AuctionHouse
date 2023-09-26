using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AutoAuctionProjekt.Classes
{
    public class Auction
    {
        Vehicle _vehicle;
        ISeller _seller;
        decimal _minimumPrice;
        public Auction(Vehicle Vehicle, ISeller Seller, decimal MinimumPrice)
        {
            _vehicle = Vehicle;
            _seller = Seller;
            _minimumPrice = MinimumPrice;
        }
        /// <summary>
        /// ID of the auction
        /// </summary>
        public uint ID { get; private set; }
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
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}