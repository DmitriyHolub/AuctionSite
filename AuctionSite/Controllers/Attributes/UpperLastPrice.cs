using AuctionSite.EfStaff.Repositories;
using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using AuctionSite.Models;

namespace AuctionSite.Controllers.Attributes
{
    public class UpperLastPrice : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _lotRepository = validationContext.GetService(typeof(LotRepository)) as LotRepository;

            var lotId = (validationContext.ObjectInstance as PlaceBetModel).LotId;

            var lotPrice = _lotRepository.GetById(lotId).BuyoutPrice;

            if(lotPrice < (double)value)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("New price must be upper than last price");
        }
    }
}
