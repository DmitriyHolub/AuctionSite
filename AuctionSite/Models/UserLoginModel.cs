using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Input Login please.")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Input password please.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
