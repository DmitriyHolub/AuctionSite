using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Enum;
namespace AuctionSite.Models
{
    public class ShowLotsModel
    {
        public long Id { get; set; }
        public string LotName { get; set; }
        public double BuyoutPrice { get; set; }
        public string ProductDescription { get; set; }
        public DateTime FinishBidding { get; set; }        
        public virtual List<string> UrlImages { get; set; }
    }
}
