using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Controllers.Attributes
{
    public class OnlyAuthorized: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _userService = context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;
            if (_userService.GetCurrentUser()==null)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
