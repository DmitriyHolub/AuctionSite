using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Models
{
    public class BankCard : BaseModel
    {
        public virtual User Owner { get; set; }
    }
}
