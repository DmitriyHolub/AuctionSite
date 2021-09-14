using AuctionSite.EfStaff.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Models
{
    public class ExchangeRate : BaseModel
    {
        public CurrencyEnum TypeCurrency { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Abbreviation { get; set; }
    }
}
