using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AuctionSite.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }

        public UserService(IUserRepository userRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public User GetCurrentUser()
        {
            var userId = _httpContextAccessor
                 .HttpContext
                 .User
                 .Claims
                 .SingleOrDefault(x => x.Type == "Id")
                 ?.Value;

            if (userId == null)
            {
                return null;
            }

            return _userRepository.GetById(long.Parse(userId));
        }
    }
}
