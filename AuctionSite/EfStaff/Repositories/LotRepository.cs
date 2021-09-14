using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class LotRepository : BaseRepository<Lot>
    {
        public LotRepository(AuctionSiteDbContext auctionSiteDbContext) 
            : base(auctionSiteDbContext)
        {
        }
        public List<Lot> GetActiveLots(int numberPage)
        {
            const int NumberOfElemts = 10;

            return _dbSet.Where(x => x.StatusLot == Enum.StatusLotEnum.Active).
                Skip(numberPage * NumberOfElemts).
                Take(NumberOfElemts).
                ToList();
        }
        public int GetCountOfActiveLots()
        {

            return _dbSet.Where(x => x.StatusLot == Enum.StatusLotEnum.Active).
                Count();
        }
        public List<Lot> GetExpiredLots(DateTime dateTime)
        {
            return _dbSet.Where(x => x.FinishBidding <= dateTime && x.StatusLot == Enum.StatusLotEnum.Active).ToList();
        }
        public List<Lot> GetLotsWithMistakes(long userId)
        {
            return _dbSet.Where(x=>x.StatusLot == Enum.StatusLotEnum.CheckedWithMistake && x.UserCreator.Id == userId).ToList();
        }

    }
}
