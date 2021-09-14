using AuctionSite.EfStaff.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuctionSite.EfStaff.Models
{
    public class TypeLot : BaseModel
    {
        public LotTypeEnum TypeOfLot { get; set; }
        public virtual List<Lot> Lots { get; set; }
        public virtual List<User> UserFavoriteTypeOfLot { get; set; }
    }
}
