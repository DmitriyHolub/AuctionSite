using AuctionSite.Controllers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Localize;

namespace AuctionSite.Models
{
    public class RegistrationUserModel
    {
        [Required(
            ErrorMessageResourceType = typeof(Resource), 
            ErrorMessageResourceName = nameof(Resource.Input_Login_please))]
        [StringLength(20, MinimumLength =3,
             ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName = nameof(Resource.Attribute_Login_length))]
        [UniqLogin]
        public string Login { get; set; }

        [Required(ErrorMessage = "Input Email please.")]
        [EmailAddress(ErrorMessage ="This is not Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Input password please.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm the password please.")]
        public string CheckPassword { get; set; }
    }
}
