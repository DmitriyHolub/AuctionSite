using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    public interface ILotImageRepository:IBaseRepository<LotImage>
    {
        public List<string> GetUrlImage();

        public List<LotImage> GetAllByID(List<long> ListId);

        public List<LotImage> GetAllByUrl(List<string> ListUrl);

    }
}
