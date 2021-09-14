using AuctionSite.EfStaff.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Models
{
    public class Lot: BaseModel
    {
        public string LotName { get; set; }
        public StatusLotEnum StatusLot { get; set; }
        public double StartPrice { get; set; }
        public double BuyoutPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool CheckAdmin { get; set; }
        public DateTime StartBidding { get; set; }
        public DateTime FinishBidding { get; set; }
        public string MistakeAfterCheck { get; set; }

        public virtual User LastBidUser { get; set; }
        public virtual User UserCreator { get; set; }
        public virtual List<User> Observers { get; set; }
        public virtual List<LotImage> UrlImages { get; set; }
        public virtual TypeLot TypeOfLot { get; set; }
    }
}
