using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Repositories.Interfaces
{
    interface IExchangeRateRepository:IBaseRepository<ExchangeRate>
    {
        public bool Exist(string name);
    }
}
