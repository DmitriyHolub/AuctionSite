using AuctionSite.EfStaff.Repositories;
using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Controllers.Attributes.AuthAttribute
{
    public class OnlyAdmin: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _userService = context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;
            if (_userService.GetCurrentUser().TypeOfUSer != EfStaff.Enum.UserTypeEnum.Admin)
            {
                context.Result = new ForbidResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
