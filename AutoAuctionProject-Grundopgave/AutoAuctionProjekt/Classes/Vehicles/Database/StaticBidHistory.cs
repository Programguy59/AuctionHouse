using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoAuctionProjekt.Util;

namespace AutoAuctionProjekt.Classes.Vehicles.Database
{
    public static partial class Database
    {
        public static readonly List<BidHistory> BidHistory = new();

        public static BidHistory? GetBidByAUctionId(int id)
        {
            if (BidHistory.FirstOrDefault(bid => bid.AuctionId == id) == null)
            { return null; }
            return BidHistory.FirstOrDefault(bid => bid.AuctionId == id);

        }

        public static BidHistory? GetBidByUserName(string userName)
        {
            return BidHistory.FirstOrDefault(bid => bid.UserName == userName);
        }

        public static BidHistory GetHigestBidOnAuction(int id)
        {
                BidHistory higestBid = GetBidByAUctionId(id);
                foreach (BidHistory bid in BidHistory)
                {
                    if (bid.BidAmount > higestBid.BidAmount && bid.Id == id)
                    {
                        higestBid = bid;
                    }
                }
                return higestBid;
           
        }

        public static BidHistory GetHigestBidOnAuctionForUser(string userName,int id)
        {
            BidHistory higestBid = GetBidByAUctionId(id);
            foreach (BidHistory bid in BidHistory)
            {
                if (bid.BidAmount > higestBid.BidAmount && bid.UserName == userName)
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
