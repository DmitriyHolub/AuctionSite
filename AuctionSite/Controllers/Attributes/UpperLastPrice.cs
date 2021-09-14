using AuctionSite.EfStaff.Repositories;
using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Controllers.Attributes
{
    public class UpperLastPrice : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _lotRepository = validationContext.GetService(typeof(LotRepository)) as LotRepository;

            

            //if (!_lotRepository.IsNameExist(value.ToString()))
            //{
            //    return ValidationResult.Success;
            //}
            return new ValidationResult("This namealready exist");
        }
    }
}
