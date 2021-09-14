using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Controllers.Attributes
{
    public class OnlyUser: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _userService = context.HttpContext.RequestServices.GetService(typeof(UserService)) as UserService;

            var user = _userService.GetCurrentUser();

            if (user == null)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
                base.OnActionExecuting(context);
                return;
            }

            if (_userService.GetCurrentUser().TypeOfUSer != EfStaff.Enum.UserTypeEnum.User) //ddddddd
            {
                context.Result = new RedirectToActionResult("Registration", "User", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
