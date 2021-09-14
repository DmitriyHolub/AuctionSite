using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class AdminPageModel
    {
        public bool CheckAdmin { get; set; }
        public string TextMistake { get; set; }
        public int CountOfLotToCheck{ get; set; }
        public Lot LotToCheck { get; set; }
    }
}
