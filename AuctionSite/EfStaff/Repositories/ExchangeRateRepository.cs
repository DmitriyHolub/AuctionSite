using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class ExchangeRateRepository : BaseRepository<ExchangeRate>
    {
        public ExchangeRateRepository(AuctionSiteDbContext auctionSiteDbContext) : base(auctionSiteDbContext)
        {
        }
        public bool Exist(string name)
        {
            return _dbSet.Any(x => x.Abbreviation == name);
        }
    }
}
