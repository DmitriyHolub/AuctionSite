using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    interface IUserRepository: IBaseRepository<User>
    {
        public bool Exist(string login);

        public User GetByLogin(string login);

        public User GetByLoginAndPassword(string login, string password);

        public bool IsNameExist(string login);

    }
}
