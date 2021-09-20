using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using AuctionSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionSite.Localize;
using AutoMapper;
using AuctionSite.Services;
using AuctionSite.Controllers.Attributes.AuthAttribute;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AuctionSite.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace AuctionSite.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository { get; set; }
        private ITypeLotRepository _typeLotRepository { get; set; }
        private ILotRepository _lotRepository { get; set; }
        private IMapper _mapper { get; set; }
        private IUserService _userService { get; set; }
        private IEmailService _emailService { get; set; }
        //private readonly UserManager<User> _userManager; 

        public UserController(IUserRepository userRepository,
            ITypeLotRepository typeLotRepository,
            ILotRepository lotRepository,
            IMapper mapper,
            IUserService userService,
            IEmailService emailService
            /*UserManager<User> userManager*/) 
        {
            _userRepository = userRepository;
            _typeLotRepository = typeLotRepository;
            _lotRepository = lotRepository;
            _mapper = mapper;
            _userService = userService;
            _emailService = emailService;
           /* _userManager = userManager*/;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var vievModel = new UserLoginModel()
            {
                ReturnUrl = ReturnUrl
            };
            return View(vievModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }

            var user = _userRepository.GetByLoginAndPassword(userLogin.Login, userLogin.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(UserLoginModel.Login),
                    "Wrong Login or password");
                return View(userLogin);
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Login));
            claims.Add(new Claim(
                ClaimTypes.AuthenticationMethod,
                Startup.AuthName));

            var claimsIdentity = new ClaimsIdentity(claims, Startup.AuthName);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            if (string.IsNullOrEmpty(userLogin.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(userLogin.ReturnUrl);
        }
        [HttpGet]
        public IActionResult Profile()
        {
            var viewModel = new UserProfileModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Profile(UserProfileModel userProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(userProfile);
            }

            var user = _userService.GetCurrentUser(); 

            user.Name = userProfile.Name;
            user.Surname = userProfile.SurName;
            user.PhoneNumber = userProfile.PhoneNumber;
            user.TypeOfUSer = EfStaff.Enum.UserTypeEnum.User;

            var selected = userProfile.FavoriteTypesOfLots.Select(x => x).ToList();

            user.FavoriteTypesOfLots = _typeLotRepository.GetAll().Where(x => selected.Contains(x.TypeOfLot)).ToList();

            _userRepository.Save(user);
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationUserModel registrationUser)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationUser);
            }

            var user = new User()
            {
                Login = registrationUser.Login,
                Email = registrationUser.Email,
                Password = registrationUser.Password,
                TypeOfUSer = EfStaff.Enum.UserTypeEnum.Observer
            };

            _userRepository.Save(user);

            //var code = Guid.NewGuid();

            //var callbackUrl = Url.Action(
            //           "ConfirmEmail",
            //           "User",
            //           new { userId = user.Id, code = code },
            //           protocol: HttpContext.Request.Scheme);

            //var header = "Confirm Email";

            //var text = $"Confirm your registration by clicking on the link <a href='{callbackUrl}'>link</a>";


            //_emailService.ConfirmEmail(user.Email, code, callbackUrl, header,text);

            var textMessage = $"Все хорошо {registrationUser.Login}"; //email

            _emailService.SendMessage(registrationUser.Email, textMessage);

            return RedirectToAction("Profile", "User");

            //return RedirectToAction("FinishForm", "Home",
            //    new FinishFormModel() { FinishMessage = "To complete the registration, check your email and follow the link provided in the email" });
        }
        [OnlyAdmin]
        [HttpGet]
        public IActionResult AdminPage(int number = 1)
        {
            var allUncheckedLots = _lotRepository.GetAll()
                .Where(x => !x.CheckAdmin
                        && x.StatusLot == EfStaff.Enum.StatusLotEnum.NotChecked).ToList();

            if (allUncheckedLots.Any())
            {
                var lotToCheck = allUncheckedLots[number - 1];

                var viewModel = new AdminPageModel()
                {
                    LotToCheck = lotToCheck,
                    CountOfLotToCheck = allUncheckedLots.Count(),
                };
                return View(viewModel);
            }
            return RedirectToAction("FinishForm", "Home", new { message = Resource.Message_end_admin_check });
        }
        [OnlyAdmin]
        [HttpPost]
        public IActionResult AdminPage(AdminPageModel adminPageModel)
        {
            var checkedLot = _lotRepository.GetById(adminPageModel.LotToCheck.Id);

            if (adminPageModel.CheckAdmin)
            {
                checkedLot.CheckAdmin = true;
                checkedLot.StatusLot = EfStaff.Enum.StatusLotEnum.Active;
                checkedLot.FinishBidding = DateTime.Today.Date.AddDays(10).AddHours(18);
                checkedLot.BuyoutPrice = checkedLot.StartPrice;

                _lotRepository.Save(checkedLot);

                _emailService.SendMessage(checkedLot.UserCreator.Email, $"Your lot {checkedLot.LotName} activate." +
                    $" The Auction will finished {checkedLot.FinishBidding}");

                return Redirect("AdminPage");
            }
            else
            {
                checkedLot.StatusLot = EfStaff.Enum.StatusLotEnum.CheckedWithMistake;
                checkedLot.MistakeAfterCheck = adminPageModel.TextMistake;

                _lotRepository.Save(checkedLot);
            }
            return Redirect("AdminPage");
        }
        [HttpGet]
        public IActionResult UserPage()
        {
            var user = _userService.GetCurrentUser();
            var viewModel = new UserPageModel();

            viewModel.LotsWithMistakes = _lotRepository.GetLotsWithMistakes(user.Id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UserPage(UserPageModel userPageModel) // Доделать
        {

            return View();
        }
        public IActionResult LoginValidate(string login) // from ajax
        {
            var isUniq = !_userRepository.Exist(login);
            return Json(isUniq);
        }
        //public async Task<IActionResult> ConfirmEmail(string userId, string code)
        //{
        //    var user = _userRepository.GetById((long.Parse(userId)));

        //    if (user == null || code == null)
        //    {
        //        return RedirectToAction("FinishForm", "Home",
        //        new FinishFormModel() { FinishMessage = "Error. " });
        //    };

        //    //var result = await _userManager.ConfirmEmailAsync(user, code);


        //    if (result.Succeeded)
        //    {
        //        user.ConfirmEmail = true;
        //        _userRepository.Save(user);

        //        return RedirectToAction("Profile", "User");
        //    }

        //    return RedirectToAction("FinishForm", "Home",
        //   new FinishFormModel() { FinishMessage = "Error. " });
        //}
    }
}
