using AuctionSite.EfStaff.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    interface IExchangeService
    {
        public double GetCurrentPrice(double price, CurrencyEnum currency);

        public double ExchangeToBaseCurrency(double price, CurrencyEnum currency);

    }
}
