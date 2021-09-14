using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class LotImageRepository : BaseRepository<LotImage>
    {
        public LotImageRepository(AuctionSiteDbContext auctionSiteDbContext)
            : base(auctionSiteDbContext)
        {
        }
        public List<string> GetUrlImage()
        {
            return _dbSet.Select(x => x.Url).ToList();
        }
        public List<LotImage> GetAllByID(List<long> ListId)
        {
            //var result = new List<LotImage>();
            //foreach (var id in ListId)
            //{
            //    result = _dbSet.Where(x => x.Id == id).ToList();
            //}
            //return result;
            return ListId.SelectMany(x => _dbSet.Where(z => z.Id == x)).ToList();
        }
        public List<LotImage> GetAllByUrl(List<string> ListUrl)
        {
            return ListUrl.SelectMany(x => _dbSet.Where(z => z.Url == x)).ToList();
        }
    }
}
