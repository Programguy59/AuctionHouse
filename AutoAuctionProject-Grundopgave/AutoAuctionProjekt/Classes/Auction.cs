using AutoAuctionProjekt.Classes.Vehicles.Database;

namespace AutoAuctionProjekt.Classes;

public class Auction
{
    public Auction(int id, Vehicle vehicle, ISeller seller, decimal minimumPrice)
    {
        Vehicle = vehicle;
        Seller = seller;
        MinimumPrice = minimumPrice;
        ID = id;

        StandingBid = Database.GetHigestBidOnAuction(id).BidAmount;
    }

    /// <summary>
    ///     ID of the auction
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    ///     The minimum price of the auction
    /// </summary>
    public decimal MinimumPrice { get; set; }

    /// <summary>
    ///     The standing bid of the auction
    /// </summary>
    public decimal StandingBid { get; set; }

    /// <summary>
    ///     The vehicle of the auction
    /// </summary>
    public Vehicle Vehicle { get; set; }

    /// <summary>
    ///     The seller of the auction
    /// </summary>
    public ISeller Seller { get; set; }

    /// <summary>
    ///     The buyer or potential buyer of the auction
    /// </summary>
    public IBuyer Buyer { get; set; }


    public bool isDone { get; set; }
}