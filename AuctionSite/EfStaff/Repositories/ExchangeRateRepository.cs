using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Repositories.Interfaces;

namespace AuctionSite.EfStaff.Repositories
{
    public class ExchangeRateRepository : BaseRepository<ExchangeRate>, IExchangeRateRepository
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
