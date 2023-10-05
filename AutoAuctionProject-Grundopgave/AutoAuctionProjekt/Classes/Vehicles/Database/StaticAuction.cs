using System.Collections.Generic;
using System.Linq;

namespace AutoAuctionProjekt.Classes.Vehicles.Database;

public static partial class Database
{
    public static readonly List<Auction> Auctions = new();

    public static Auction? GetAuctionById(int id)
    {
        return Auctions.FirstOrDefault(Auction => Auction.ID == id);
    }

    public static List<Auction> GetAllAuctions()
    {
        return Auctions;
    }
}