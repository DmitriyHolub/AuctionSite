using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using AuctionSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Enum;
using System.Globalization;
using AuctionSite.Services;
using AutoMapper;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AuctionSite.Services.Interfaces;

namespace AuctionSite.Controllers
{
    public class HomeController : Controller
    {
        private ILotRepository _lotRepository { get; set; }
        private IUserService _userService { get; set; }
        private IExchangeService _exchangeService { get; set; }
        private IMapper _mapper { get; set; }

        public HomeController( ILotRepository lotRepository,
            IUserService userService,
            IMapper mapper,
            IExchangeService exchangeService)
        {
            _lotRepository = lotRepository;
            _userService = userService;
            _mapper = mapper;
            _exchangeService = exchangeService;
        }

        [HttpGet]
        public IActionResult Index(CurrencyEnum? currency, int numberPage = 1)
        {
            var lots = _lotRepository.GetActiveLots(numberPage - 1);

            var user = _userService.GetCurrentUser();

            var countOfActiveLots = _lotRepository.GetCountOfActiveLots();

            var showLotsModels = new List<ShowLotsModel>();

            var currencies = Enum.GetValues(typeof(CurrencyEnum)).
               Cast<CurrencyEnum>().
               Select(x => x).
               ToList();

            var viewModel = new ShowLotWrappedModel();

            viewModel.NumberOfPages = Math.Ceiling((double)countOfActiveLots / 10);

            viewModel.LotsModels = lots.
                Select(x => _mapper.Map<ShowLotsModel>(x)).
                ToList();

            if (!User.Identity.IsAuthenticated)
            {
                if (currency == null)
                {
                    viewModel.PreferCurrency = CurrencyEnum.BYN;

                    return View(viewModel);
                }

                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, (CurrencyEnum)currency), 2);
                }

                viewModel.PreferCurrency = (CurrencyEnum)currency;

                return View(viewModel);
            }

            var favoriteLots = user.FavoriteTypesOfLots
                .SelectMany(type => lots.Where(x => x.TypeOfLot.TypeOfLot == type.TypeOfLot));

            if (currency == null)
            {
                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, user.PreferingCurrency), 2);
                }

                viewModel.PreferCurrency = user.PreferingCurrency;
            }
            else
            {
                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, (CurrencyEnum)currency), 2);
                }

                viewModel.PreferCurrency = (CurrencyEnum)currency;
            }

            if (!favoriteLots.Any())
            {
                return View(viewModel);
            }

            favoriteLots.OrderBy(x => x.StartPrice);

            viewModel.LotsModels = favoriteLots.
                Select(x => _mapper.Map<ShowLotsModel>(x)).
                ToList();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string lang)
        {
            var language = int.Parse(lang);
            switch (language)
            {
                case (int)LanguageEnum.Eng:
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-EN");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-EN");
                    break;
                case (int)LanguageEnum.Rus:
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ru-Ru");
                    break;
                default:
                    throw new Exception("Unknown currency");
            }
            return View();
        }
        public IActionResult FinishForm(FinishFormModel viewModel)
        {
            return View(viewModel);
        }
        public IActionResult ActionRules()
        {
            return View();
        }
    }
}
