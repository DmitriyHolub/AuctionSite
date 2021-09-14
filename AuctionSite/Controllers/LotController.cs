using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using AuctionSite.Models;
using AuctionSite.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Localize;
using AuctionSite.Controllers.Attributes;
using System.Drawing;

namespace AuctionSite.Controllers
{
    public class LotController : Controller
    {
        private UserService _userService { get; set; }
        private LotRepository _lotRepository { get; set; }
        private TypeLotRepository _typeLotRepository { get; set; }
        private IMapper _mapper { get; set; }
        private FileService _fileService { get; set; }
        private LotImageRepository _lotImageRepository { get; set; }
        private EmailService _emailService { get; set; }
        private LotService _lotService { get; set; }
        private UserRepository _userRepository { get; set; }
        private ExchangeService _exchangeService { get; set; }
        private IReportService _reportService { get; set; }

        public LotController(UserService userService,
            LotRepository lotRepository,
            TypeLotRepository typeLot,
            IMapper mapper,
             FileService fileService,
             LotImageRepository lotImageRepository,
             EmailService emailService,
             LotService lotService,
             UserRepository userRepository,
             ExchangeService exchangeService,
             ReportService reportService)
        {
            _userService = userService;
            _lotRepository = lotRepository;
            _typeLotRepository = typeLot;
            _mapper = mapper;
            _fileService = fileService;
            _lotImageRepository = lotImageRepository;
            _emailService = emailService;
            _lotService = lotService;
            _userRepository = userRepository;
            _exchangeService = exchangeService;
            _reportService = reportService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult SetLot()
        {
            var viewModel = new SetLotModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SetLot(SetLotModel lotModel)
        {
            if (!ModelState.IsValid)
            {
                return View(lotModel);
            }
            var user = _userService.GetCurrentUser();

            var newLot = _mapper.Map<Lot>(lotModel);

            newLot.UserCreator = user;
            newLot.TypeOfLot = _typeLotRepository.GetTypeByNameOFType(lotModel.LotType);
            newLot.StatusLot = StatusLotEnum.NotChecked;

            _lotRepository.Save(newLot);

            foreach (var image in lotModel.LotImages)
            {
                var newlotImage = new LotImage() { Image = newLot };

                _lotImageRepository.Save(newlotImage);

                var fullPath = Path.Combine(_fileService.GeyPathForImage(), $"{newlotImage.Id}.jpg");

                using (var stream = new FileStream(fullPath, FileMode.OpenOrCreate))
                {
                    image.CopyTo(stream);
                }
                newlotImage.Url = _fileService.GetImageUrl(newlotImage.Id);

                _lotImageRepository.Save(newlotImage);
            }

            return RedirectToAction("FinishForm", "Home",
                new FinishFormModel() { FinishMessage = $"{Resource.Message_end_set_Lot}" });
        }
        [HttpGet]
        public IActionResult ShowLots(LotTypeEnum numberType, CurrencyEnum? currency)
        {
            var viewModel = new ShowLotByTypeModel();

            viewModel.numberType = numberType;
            var user = _userService.GetCurrentUser();

            var lots = new List<Lot>();
            switch (numberType)
            {
                case LotTypeEnum.Equipment:
                    lots = _lotRepository.GetAll().Where(x => x.TypeOfLot.Id == (long)LotTypeEnum.Equipment &&
                    x.StatusLot == StatusLotEnum.Active).ToList();
                    break;
                case LotTypeEnum.Books:
                    lots = _lotRepository.GetAll().Where(x => x.TypeOfLot.Id == (long)LotTypeEnum.Books &&
                    x.StatusLot == StatusLotEnum.Active).ToList();
                    break;
                case LotTypeEnum.Vehicles:
                    lots = _lotRepository.GetAll().Where(x => x.TypeOfLot.Id == (long)LotTypeEnum.Vehicles &&
                    x.StatusLot == StatusLotEnum.Active).ToList(); ;
                    break;
                case LotTypeEnum.Antiques:
                    lots = _lotRepository.GetAll().Where(x => x.TypeOfLot.Id == (long)LotTypeEnum.Antiques &&
                    x.StatusLot == StatusLotEnum.Active).ToList();
                    break;
                case LotTypeEnum.Others:
                    lots = _lotRepository.GetAll().Where(x => x.TypeOfLot.Id == (long)LotTypeEnum.Others &&
                    x.StatusLot == StatusLotEnum.Active).ToList();
                    break;
                default:
                    throw new Exception("Unknown type of lot");
            }

            viewModel.LotsModels = lots.Select(x => _mapper.Map<ShowLotsModel>(x)).ToList();

            if (!User.Identity.IsAuthenticated)
            {
                if (currency == null)
                {
                    viewModel.PreferCurrency = CurrencyEnum.BYN;

                    return View(viewModel);
                }

                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, (CurrencyEnum)currency),2);
                }

                viewModel.PreferCurrency = (CurrencyEnum)currency;

                return View(viewModel);
            }

            if (currency == null) // for Authenticated user
            {
                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, user.PreferingCurrency),2);
                }

                viewModel.PreferCurrency = user.PreferingCurrency;
            }
            else
            {
                foreach (var item in viewModel.LotsModels)
                {
                    item.BuyoutPrice = Math.Round(_exchangeService.GetCurrentPrice(item.BuyoutPrice, (CurrencyEnum)currency),2);
                }

                viewModel.PreferCurrency = (CurrencyEnum)currency;
            }

            return View(viewModel);
        }
        [HttpGet]
        //[OnlyAuthorized]
        [OnlyUser]
        public IActionResult PlaceBet(long lotId)
        {
            if (!User.Identity.IsAuthenticated) //Вопрос ReturnUrl@@@@@@@@@@@@@@@@@@@
            {
                return RedirectToAction("Registration", "User");
            }

            var user = _userService.GetCurrentUser();

            if (user.TypeOfUSer == UserTypeEnum.Observer)//Вопрос ReturnUrl@@@@@@@@@@@@@@@@@@@
            {
                return RedirectToAction("Registration", "User");
            }

            var viewModel = new PlaceBetModel() { LotId = lotId };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult PlaceBet(PlaceBetModel placeBetModel)
        {
            if (!ModelState.IsValid)
            {
                return View(placeBetModel);
            }

            var NewBasePrice = _exchangeService.ExchangeToBaseCurrency(placeBetModel.NewPrice, placeBetModel.Currency);

            var user = _userService.GetCurrentUser();

            var lot = _lotRepository.GetById(placeBetModel.LotId);

            lot.BuyoutPrice = NewBasePrice;

            lot.LastBidUser = user;

            _lotRepository.Save(lot);

            user.Rating += 1;

            _userRepository.Save(user);

            _lotService.SendEmailToObserves(lot.Id);

            return RedirectToAction("FinishForm", "Home",
                 new FinishFormModel() { FinishMessage = $"{Resource.Place_bet_finish_phrase} {lot.LotName}" });
        }

        [HttpGet]
        public IActionResult Subscribe(long lotId)
        {
            if (!User.Identity.IsAuthenticated) //Вопрос ReturnUrl@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            {
                return RedirectToAction("Registration", "User");
            }

            var user = _userService.GetCurrentUser();

            var lot = _lotRepository.GetById(lotId);

            if (user.ObservedLots.Any(x => x == lot))
            {
                return RedirectToAction("FinishForm", "Home",
                new FinishFormModel() { FinishMessage = $"{Resource.Subscribe_finish} {lot.LotName}" }); // Сообщение вы подписаны уже
            }

            user.ObservedLots.Add(lot);

            return RedirectToAction("FinishForm", "Home",
                new FinishFormModel() { FinishMessage = $"{Resource.Subscribe_finish} {lot.LotName}" });
        }
        public IActionResult DownLoadLot(long lotId,CurrencyEnum currency)
        {
            var lot = _lotRepository.GetById(lotId);

            lot.BuyoutPrice = _exchangeService.GetCurrentPrice(lot.BuyoutPrice, currency);

           var pdfFile =  _reportService.GeneratePdfReport(lot, currency);

            return File(pdfFile,
           "application/octet-stream", "LotPdf.pdf");
        }
    }
}
