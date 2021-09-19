using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Localize;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuctionSite.Models
{
    public class SetLotModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName =nameof(Resource.Attribures_Input_name_Lot))]      
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Too big description. Make it shorter please")]
        public string LotName { get; set; }

        [Required(ErrorMessage = "Input start price of lot please.")]
        [Range(1, 100000, ErrorMessage = "The price need to be more than 1 and less than 100000.")]
        public double StartPrice { get; set; }

        [Required(ErrorMessage = "Input description of lot please.")]
        [StringLength(200, ErrorMessage = "Too big description. Make it shorter please")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Choose type of lot please.")]
        public LotTypeEnum LotType { get; set; }

        public IEnumerable<SelectListItem> AllTypeOfLots 
        {
            get
            {
               return Enum.GetValues(typeof(LotTypeEnum)).Cast<LotTypeEnum>().
                    Select(x => new SelectListItem(x.ToString(), x.ToString()));
            }
        }

        [Required(ErrorMessage = "Needed foto")]
        public List<IFormFile> LotImages { get; set; } 
    }
}
