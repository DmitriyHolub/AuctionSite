using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class TypeLotRepository : BaseRepository<TypeLot>
    {
        public TypeLotRepository(AuctionSiteDbContext auctionSiteDbContext) : base(auctionSiteDbContext)
        {
        }
        public bool Exist(LotTypeEnum type)
        {
            return _dbSet.Any(x => x.TypeOfLot == type);
        }
        public List<LotTypeEnum> GetTypesOfLot()
        {
            return _dbSet.Select(x=>x.TypeOfLot).ToList();
        }
        public TypeLot GetTypeByNameOFType(LotTypeEnum type )
        {
            return _dbSet.FirstOrDefault(x=>x.TypeOfLot == type);
        }
    }
}
