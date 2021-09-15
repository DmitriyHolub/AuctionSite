using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Repositories.Interfaces;

namespace AuctionSite.EfStaff.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AuctionSiteDbContext DbContext) 
            : base(DbContext)
        {
        }
        
        public bool Exist(string login)
        {
            return _dbSet.Any(x => x.Login == login);
        }
        public User GetByLogin(string login)
        {
            return _dbSet.FirstOrDefault(x => x.Login == login);
        }
        public User GetByLoginAndPassword(string login,string password)
        {
            return _dbSet.FirstOrDefault(x => x.Login == login && x.Password == password);
        }
        public bool IsNameExist(string login)
        {
            return _dbSet.Any(x => x.Login == login);
        }
    }

}
