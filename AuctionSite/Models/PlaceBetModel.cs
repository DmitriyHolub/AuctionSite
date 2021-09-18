using AuctionSite.Controllers.Attributes;
using AuctionSite.EfStaff.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class PlaceBetModel
    {
        [Display(Name ="lotId")]
        public long LotId { get; set; }
        public string LotName { get; set; }
        [Required]
        [UpperLastPrice]
        public double NewPrice { get; set; }
        public CurrencyEnum Currency { get; set; }

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
