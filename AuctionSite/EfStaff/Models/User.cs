using AuctionSite.EfStaff.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserTypeEnum TypeOfUSer { get; set; }
        public int Rating { get; set; }
        public CurrencyEnum PreferingCurrency { get; set; }
        public bool ConfirmEmail { get; set; }
        //public string CodeConfirmEmail { get; set; }

        public virtual List<TypeLot> FavoriteTypesOfLots { get; set; }      
        public virtual List<BankCard> UsersBankCards { get; set; }
        public virtual List<Lot> LotsCreatedByUser { get; set; }
        public virtual List<Lot> ObservedLots { get; set; }
        public virtual List<Lot> BuyerLot { get; set; }
        



    }
}
