using AuctionSite.EfStaff.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Repositories;
using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Repositories.Interfaces;

namespace AuctionSite.EfStaff
{
    public static class SeedExtension
    {
        public const string admin = "Admin";
        public const string client1 = "Brad";
        public const string client2 = "Mike";

        public const string lot1 = "Oskar";
        public const string lot2 = "Samokat";

        public const string Image1 = "/LotImages/Оскар.jpg";
        public const string Image2 = "/LotImages/Оскар1.jpg";
        public const string Image3 = "/LotImages/Оскар2.jpg";
        public const string Image4 = "/LotImages/Самокат1.jpg";
        public const string Image5 = "/LotImages/Самокат2.jpg";

        public const string TypeOfLot1 = " Equipment";
        public const string TypeOfLot2 = " Books";
        public const string TypeOfLot3 = " Vehicles";
        public const string TypeOfLot4 = " Antiques";
        public const string TypeOfLot5 = " Others";

        public const string RateUSD = "USD";
        public const string RateEUR = "EUR";
        public const string RateRUB = "RUB";
        public const string RateBYN = "BYN";

        public static IHost Seed(this IHost host)
        {
            using (var services = host.Services.CreateScope())
            {
                initTypeOFLot(services.ServiceProvider);
                InitUser(services.ServiceProvider);
                InitImages(services.ServiceProvider);
                InitLot(services.ServiceProvider);
                InitExchangeRates(services.ServiceProvider);
                
            }
            return host;
        }

        private static void InitExchangeRates(IServiceProvider service)
        {
            var _exchangeRateRepository = service.GetService<IExchangeRateRepository>();

            var rates = new List<string>() { RateUSD, RateEUR, RateRUB, RateBYN };

            var rateInfo = new Dictionary<string, CurrencyEnum>()
            {
                {RateUSD,CurrencyEnum.USD},
                {RateEUR,CurrencyEnum.EUR},
                {RateRUB,CurrencyEnum.RUB},
                {RateBYN,CurrencyEnum.BYN},
            };

            foreach (var rate in rates)
            {
                if (!_exchangeRateRepository.Exist(rate))
                {
                    var newRAte = new ExchangeRate()
                    {
                        Abbreviation = rate,
                        TypeCurrency = rateInfo.First(x => x.Key == rate).Value,
                        Rate = 1   
                    };

                    _exchangeRateRepository.Save(newRAte);
                }
            }
        }

        public static void InitUser(IServiceProvider service)
        {
            var _userRepository = service.GetService<IUserRepository>();
            var _typeLotRepository = service.GetService<ITypeLotRepository>();

            var userInfo = new Dictionary<string, User>()
            {
                { admin ,
                    new User(){Login=admin,
                        Email = "6367394@mai.ru",
                        Name ="Дмитрий",
                        TypeOfUSer = UserTypeEnum.Admin,
                        Password ="123456A",
                        PhoneNumber ="+375296367394",
                    FavoriteTypesOfLots = null,
                    PreferingCurrency = CurrencyEnum.BYN}},
                { client1,
                    new User(){Login=client1,
                        Email = "6204400@bk.ru",
                        Name ="Brad",
                        TypeOfUSer = UserTypeEnum.User,
                        Password ="123456Z",
                        PreferingCurrency = CurrencyEnum.EUR,
                        PhoneNumber ="+375293609000",
                    FavoriteTypesOfLots = null}},
                { client2 ,
                    new User(){Login=client2,
                        Email = "GolubDm@Tut.by",
                        Name ="Mike",
                        TypeOfUSer = UserTypeEnum.User,
                        Password ="123456Q",
                        PreferingCurrency = CurrencyEnum.USD,
                        PhoneNumber ="+375333609000",
                        FavoriteTypesOfLots = new List<TypeLot>(){_typeLotRepository.GetById(3) }
                    }}
            };

            var logins = new List<string> { admin, client1, client2 };

            foreach (var login in logins)
            {
                if (!_userRepository.Exist(login))
                {
                    var newUser = userInfo.First(x => x.Key == login).Value;

                    _userRepository.Save(newUser);
                }
            }
        }
        public static void initTypeOFLot(IServiceProvider service)
        {
            var _typeLotRepository = service.GetService<ITypeLotRepository>();

            var typeInfo = new List<string>() { TypeOfLot1, TypeOfLot2, TypeOfLot3, TypeOfLot4, TypeOfLot5 };

            var typyLotInfo = new Dictionary<string, LotTypeEnum>()
            {
                {TypeOfLot1,LotTypeEnum.Equipment},
                {TypeOfLot2,LotTypeEnum.Books},
                {TypeOfLot3,LotTypeEnum.Vehicles},
                {TypeOfLot4,LotTypeEnum.Antiques},
                {TypeOfLot5,LotTypeEnum.Others},
            };

            foreach (var item in typeInfo)
            {
                if (!_typeLotRepository.Exist(typyLotInfo.First(x=>x.Key == item).Value))
                {
                    var newType = new TypeLot() { TypeOfLot = typyLotInfo.First(x=>x.Key == item).Value };

                    _typeLotRepository.Save(newType);
                }
            }
        }
        public static void InitImages(IServiceProvider service)
        {
            var _lotImageRepositoty = service.GetService<ILotImageRepository>();

            var allLotImages = _lotImageRepositoty.GetAll();

            var necessaryImage = new List<string>() { Image1, Image2, Image3, Image4, Image5 };

            foreach (var image in necessaryImage)
            {
                if (!allLotImages.Any(x => x.Url == image))
                {
                    var newImage = new LotImage() { Url = image };

                    _lotImageRepositoty.Save(newImage);
                }
            }
        }

        public static void InitLot(IServiceProvider service)
        {
            var _userRepository = service.GetService<IUserRepository>();
            var _lotRepository = service.GetService<ILotRepository>();
            var _lotImageRepository = service.GetService<ILotImageRepository>();
            var _typeLotRepository = service.GetService<ITypeLotRepository>();

            var OskarImagesUrl = new List<string>() { Image1, Image2, Image3 };
            var SamokatImagesUrl = new List<string>() { Image4, Image5 };

            var lotInfo = new Dictionary<string, Lot>()
            {
                { "Oskar" ,
                    new Lot(){LotName = "Oskar"
                    ,StartPrice = 50
                    ,ProductDescription ="Отрываю от сердца"
                    ,UserCreator = _userRepository.GetByLogin("Brad")
                    ,TypeOfLot =_typeLotRepository.GetAll().FirstOrDefault(x=>x.TypeOfLot==LotTypeEnum.Others)
                    ,UrlImages  =_lotImageRepository.GetAllByUrl(OskarImagesUrl),
                    StatusLot = StatusLotEnum.NotChecked} },
                { "Samokat" ,
                      new Lot(){LotName = "Samokat"
                      ,StartPrice = 100
                      ,ProductDescription ="очень быстрый"
                      ,UserCreator = _userRepository.GetByLogin("Mike")
                      ,TypeOfLot =_typeLotRepository.GetAll().First(x=>x.TypeOfLot==LotTypeEnum.Vehicles)
                      ,UrlImages  =_lotImageRepository.GetAllByUrl(SamokatImagesUrl),
                       StatusLot = StatusLotEnum.NotChecked} }
            };

            var nameLots = new List<string> { lot1, lot2 };

            foreach (var lot in nameLots)
            {
                if (!_lotRepository.GetAll().Any(x => x.LotName == lot))
                {
                    var newLot = lotInfo.First(x => x.Key == lot).Value;

                    _lotRepository.Save(newLot);
                }
            }
        }
    }
}
