using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AuctionSite.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSiteTest.Services
{
    class ExchangeServiceTest
    {
        private Mock<IExchangeRateRepository> _exchangeRateRepository;
        private ExchangeService _exchangeService;

        private List<ExchangeRate> _allExchangedRates { get; set; }
        [SetUp]
        public void SetUp()
        {
            _exchangeRateRepository = new Mock<IExchangeRateRepository>();
            _exchangeService = new ExchangeService(_exchangeRateRepository.Object);
            _allExchangedRates = new List<ExchangeRate>()
            {
                new ExchangeRate() { TypeCurrency = CurrencyEnum.EUR, Rate =3},
                new ExchangeRate() { TypeCurrency = CurrencyEnum.USD, Rate =2},
                new ExchangeRate() { TypeCurrency = CurrencyEnum.RUB, Rate =4 }
            };
        }
        [Test]
        [TestCase(10, CurrencyEnum.USD,5)]
        [TestCase(9, CurrencyEnum.EUR,3)]
        [TestCase(10, CurrencyEnum.RUB,250)]
        public void GetCurrentPrice_Test(double price, CurrencyEnum currency, double answer)
        {
            //Preparing  
            _exchangeService.allExchangedRates = _allExchangedRates;
            //Act 
            var result = _exchangeService.GetCurrentPrice(price, currency);
            //Assert
            Assert.AreEqual(result, answer);
       

        }
    }
}

    //public double GetCurrentPrice(double price, CurrencyEnum currency)
    //{
    //    if (currency == CurrencyEnum.RUB)
    //    {
    //        return Math.Round(price * 100 / allExchangedRates.First(x => x.TypeCurrency == currency).Rate, 2); // yt ghfdbkmyj
    //    }

    //    return Math.Round(price / allExchangedRates.First(x => x.TypeCurrency == currency).Rate, 2);
    //}
    //public double ExchangeToBaseCurrency(double price, CurrencyEnum currency)
    //{
    //    if (currency == CurrencyEnum.RUB)
    //    {
    //        return Math.Round(price / 100 * allExchangedRates.First(x => x.TypeCurrency == currency).Rate);
    //    }

    //    return Math.Round(price * allExchangedRates.First(x => x.TypeCurrency == currency).Rate);
    //}

