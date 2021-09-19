using AuctionSite.EfStaff.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class ShowSelectedLotModel
    {
        public long Id { get; set; }
        public string LotName { get; set; }
        public double BuyoutPrice { get; set; }
        public string ProductDescription { get; set; }
        public DateTime FinishBidding { get; set; }
        public string UrlImage { get; set; }
        public CurrencyEnum PreferCurrency { get; set; }
        public virtual List<string> UrlImages { get; set; }

        public CurrencyEnum Currency { get; set; }

        public double NumberOfPages { get; set; }

        public IEnumerable<SelectListItem> Currencies
        {
            get
            {
                return Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().
                    Select(x => new SelectListItem(x.ToString(), x.ToString()));
            }
        }
    }
}
