using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class TypesForChooseModel
    {
       public LotTypeEnum TypeLot { get; set; }
        public bool IsSelected { get; set; }
    }
}
