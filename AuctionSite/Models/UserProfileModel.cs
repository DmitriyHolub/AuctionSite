using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuctionSite.Models
{
    public class UserProfileModel
    {
        [Required(ErrorMessage = "Input Name please.")]
        public string Name { get; set; }
        public string SurName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }   
        public List<LotTypeEnum> FavoriteTypesOfLots { get; set; }
        public IEnumerable<SelectListItem> AllTypesOfLots 
        {
            get
            {
                return Enum.GetValues(typeof(LotTypeEnum)).Cast<LotTypeEnum>().
                    Select(x => new SelectListItem(x.ToString(), x.ToString()));
            }

        } 
    }
}
