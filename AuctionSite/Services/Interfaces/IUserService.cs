using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    interface IUserService
    {
        public User GetCurrentUser();

    }
}
