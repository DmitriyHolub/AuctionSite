using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    public interface ILotRepository: IBaseRepository<Lot>
    {
        public List<Lot> GetActiveLots(int numberPage);

        public int GetCountOfActiveLots();

        public List<Lot> GetExpiredLots(DateTime dateTime);

        public List<Lot> GetLotsWithMistakes(long userId);

    }
}
