using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuctionProjekt.Classes
{
    public class BidHistory
    {
        public BidHistory(DateTime date, decimal bidAmound, string userName, int auctionId)
        {
            Date = date;
            BidAmount = bidAmound;
            UserName = userName;
            AuctionId = auctionId;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal BidAmount { get; set; }
        public string UserName { get; set; }
        public int AuctionId { get; set; }

    }
   

}
