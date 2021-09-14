using AuctionSite.EfStaff;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TimerHelper
{
    class CurrencyHelper
    {
        private AuctionSiteDbContext _dbContext { get; set; }

        public CurrencyHelper(AuctionSiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private const string pathCurrencyAPI = "https://www.nbrb.by/api/exrates/rates";

        private List<int> neededIdCurrencies = new List<int>() { 431, 451, 456 };
        public void GetCurrentCurrencies()
        {
            foreach (var id in neededIdCurrencies)
            {
                var request = WebRequest.Create($"{pathCurrencyAPI}/{id}");
                var response = request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var responseCurrency = reader.ReadToEnd();
                        var data = JsonSerializer.Deserialize<ResponseCurrency>(responseCurrency);

                        var rateToUpdate = _dbContext.ExchangeRates.FirstOrDefault(x => x.Abbreviation == data.Abbreviation);

                        rateToUpdate.Name = data.Name;
                        rateToUpdate.Rate = data.Rate;
                       

                        _dbContext.ExchangeRates.Update(rateToUpdate);                      
                    }
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
