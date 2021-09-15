using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    public interface IBaseRepository<Model> where Model : BaseModel
    {
        public void Save(Model model);

        public void Remove(Model model);

        public List<Model> GetAll();

        public Model GetById(long Id);

    }
}
