using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<BidHistory> BidHistory = new();

    public static BidHistory? GetBidByAUctionId(int id)
    {
        if (BidHistory.FirstOrDefault(bid => bid.AuctionId == id) == null) return null;
        return BidHistory.FirstOrDefault(bid => bid.AuctionId == id);
    }

    public static BidHistory? GetBidByUserName(string userName)
    {
        return BidHistory.FirstOrDefault(bid => bid.UserName == userName);
    }

    public static BidHistory GetHigestBidOnAuction(int id)
    {
        var higestBid = GetBidByAUctionId(id);
        foreach (var bid in BidHistory)
            if (bid.BidAmount > higestBid.BidAmount && bid.AuctionId == id)
                higestBid = bid;
        return higestBid;
    }

    public static BidHistory GetHigestBidOnAuctionForUser(string userName, int id)
    {
        var higestBid = GetBidByAUctionId(id);
        foreach (var bid in BidHistory)
            if (bid.BidAmount > higestBid.BidAmount && bid.UserName == userName && bid.Id == id)
                higestBid = bid;
        if (higestBid.UserName == userName)
            return higestBid;
        return null;
    }


    public static List<BidHistory> GetAllBidHistory()
    {
        return BidHistory;
    }
}