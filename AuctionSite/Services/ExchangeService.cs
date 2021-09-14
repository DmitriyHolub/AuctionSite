using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class ExchangeService
    {
        private ExchangeRateRepository _exchangeRateRepository { get; set; }
        private List<ExchangeRate> allExchangedRates { get; set; }

        public ExchangeService(ExchangeRateRepository exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
            allExchangedRates = _exchangeRateRepository.GetAll();
        }

        public double GetCurrentPrice(double price, CurrencyEnum currency)
        {
            if (currency == CurrencyEnum.RUB)
            {
                return Math.Round(price * allExchangedRates.First(x => x.TypeCurrency == currency).Rate, 2);
            }

            return Math.Round(price / allExchangedRates.First(x => x.TypeCurrency == currency).Rate, 2);
        }
        public double ExchangeToBaseCurrency(double price, CurrencyEnum currency)
        {
            if (currency == CurrencyEnum.RUB)
            {
                return Math.Round(price / allExchangedRates.First(x => x.TypeCurrency == currency).Rate);
            }
            return Math.Round(price * allExchangedRates.First(x => x.TypeCurrency == currency).Rate);
        }
    }
}
