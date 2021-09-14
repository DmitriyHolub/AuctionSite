using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class BankCardRepository : BaseRepository<BankCard>
    {
        public BankCardRepository(AuctionSiteDbContext auctionSiteDbContext) 
            : base(auctionSiteDbContext)
        {
        }
    }
}
