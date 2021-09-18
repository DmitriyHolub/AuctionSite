using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    public interface ITypeLotRepository:IBaseRepository<TypeLot>
    {
        public bool Exist(LotTypeEnum type);

        public List<LotTypeEnum> GetTypesOfLot();

        public TypeLot GetTypeByNameOFType(LotTypeEnum type);

    }
}
