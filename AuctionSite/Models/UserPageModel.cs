using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class UserPageModel
    {
        public List<Lot> LotsWithMistakes { get; set; }
    }
}
