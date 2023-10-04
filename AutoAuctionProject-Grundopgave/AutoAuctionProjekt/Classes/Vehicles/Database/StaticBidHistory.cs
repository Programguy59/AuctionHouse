using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Classes.Vehicles.Database
{
    public static partial class Database
    {
        public static readonly List<BidHistory> BidHistory = new();

        public static BidHistory? GetBidByAUctionId(int id)
        {
            return BidHistory.FirstOrDefault(bid => bid.AuctionId == id);
        }

        public static BidHistory? GetBidByUserName(string userName)
        {
            return BidHistory.FirstOrDefault(bid => bid.UserName == userName);
        }

        public static BidHistory GetHigestBidOnAuction(int id)
        {
            BidHistory higestBid = GetBidByAUctionId(id);
            foreach(BidHistory bid in BidHistory)
            {
                if (bid.BidAmount > higestBid.BidAmount)
                {
                    higestBid = bid;
                }
            }
            return higestBid;
        }
        public static List<BidHistory> GetAllBidHistory()
        {
            return BidHistory;
        }
    }
}
