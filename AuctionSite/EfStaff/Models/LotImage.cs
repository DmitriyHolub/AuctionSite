using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Models
{
    public class LotImage: BaseModel
    {
        public string Url { get; set; }

        public virtual Lot Image { get; set; }
    }
}
