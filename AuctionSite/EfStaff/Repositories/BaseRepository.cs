using AuctionSite.EfStaff.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories
{
    public class BaseRepository<Model> where Model: BaseModel
    {
        private AuctionSiteDbContext _auctionSiteDbContext { get; set; }
        private protected DbSet<Model> _dbSet { get; set; }

        public BaseRepository(AuctionSiteDbContext auctionSiteDbContext)
        {
            _auctionSiteDbContext = auctionSiteDbContext;
            _dbSet = _auctionSiteDbContext.Set<Model>();
        }

        public void Save(Model model)
        {
            if(model.Id > 0)
            {
                _auctionSiteDbContext.Update(model);
            }
            else
            {
                _auctionSiteDbContext.Add(model);
            }
            _auctionSiteDbContext.SaveChanges();
        }
        public void Remove(Model model)
        {
            _dbSet.Remove(model);
            _auctionSiteDbContext.SaveChanges();
        }
        public List<Model> GetAll()
        {
            return _dbSet.ToList();
        }
        public Model GetById(long Id)
        {
            return _dbSet.FirstOrDefault(x=>x.Id == Id);
        }

    }
}
