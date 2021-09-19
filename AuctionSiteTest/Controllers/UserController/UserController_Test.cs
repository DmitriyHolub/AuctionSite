using AuctionSite.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AutoMapper;
using AuctionSite.Services.Interfaces;
using AuctionSite.Services;
using AuctionSite.EfStaff.Repositories;
using NUnit.Framework;
using AuctionSite.EfStaff.Models;
using AuctionSite.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSiteTest.Controllers.UserController
{
    class UserController_Test
    {
        UserLoginModel userLoginModel = new UserLoginModel() { Login = "111", Password = "111" };
        Mock<IUserRepository> _userRepository;
        Mock<ITypeLotRepository> _typeLotRepository;
        Mock<ILotRepository> _lotRepository;
        Mock<IMapper> _mapper;
        Mock<IUserService> _userService;
        Mock<IEmailService> _emailService;
        AuctionSite.Controllers.UserController _userController;
        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _typeLotRepository = new Mock<ITypeLotRepository>();
            _lotRepository = new Mock<ILotRepository>();
            _userService = new Mock<IUserService>();
            _mapper = new Mock<IMapper>();
            _emailService = new Mock<IEmailService>();
            _userController =
                new AuctionSite.Controllers.UserController(_userRepository.Object,
                _typeLotRepository.Object,
                _lotRepository.Object,
                _mapper.Object,
                _userService.Object,
                _emailService.Object);
        }
        [Test]
        public void GetModelStateAddModelErrorIfUserNull() // Недоделано !!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            //Preparing  
            _userRepository.Setup(x => x.
            GetByLoginAndPassword(userLoginModel.Login, userLoginModel.Password)).Returns(null as User);

            //Act 
            var result = _userController.Login(userLoginModel);


            //Assert
            //var viewResult = Assert.AreEqual();
            //Assert.True(result.))

        }
        [Test]
        public void AdminPage_CheckAdminISTrue()
        {
            //Preparing  
            AdminPageModel adminPageModel = new AdminPageModel()
            { CheckAdmin = true,
                LotToCheck = new Lot() { Id = 4 }
            };

            Lot lot = new Lot()
            {
                StatusLot = AuctionSite.EfStaff.Enum.StatusLotEnum.NotChecked,
                StartPrice = 5,
                CheckAdmin = false,
                UserCreator = new User() { Email = "6367394@mail.ru" },
                FinishBidding = DateTime.Now,
                StartBidding = DateTime.Now
            };

            _lotRepository.Setup(x => x.GetById(adminPageModel.LotToCheck.Id)).Returns(lot);

            _emailService.Setup(x => x.SendMessage(lot.UserCreator.Email, "dsds"));

            //Act 
            var result = _userController.AdminPage(adminPageModel);

            //Assert
            Assert.AreEqual(lot.StatusLot,
                AuctionSite.EfStaff.Enum.StatusLotEnum.Active,
                "StatusLot must become Active");
            Assert.AreEqual(lot.BuyoutPrice, 5,
                "BuyoutPrice must take a value from StartPrice ");
            Assert.AreEqual(lot.CheckAdmin, true,
                "CheckAdmin must become true");
            Assert.AreEqual(lot.FinishBidding, DateTime.Today.Date.AddDays(10).AddHours(18),
                "FinishBidding must be plus 10 days to DateTime.Now at 18 pm");
        }
        [Test]
        public void AdminPage_CheckAdminISFalse()
        {
            //Preparing  
            AdminPageModel adminPageModel = new AdminPageModel()
            {
                CheckAdmin = false,
                LotToCheck = new Lot() { Id = 4 },
                TextMistake= "111"   
            };

            Lot lot = new Lot()
            {
                StatusLot = AuctionSite.EfStaff.Enum.StatusLotEnum.NotChecked,
                StartPrice = 5,
                CheckAdmin = false,
                MistakeAfterCheck = null

            };

            _lotRepository.Setup(x => x.GetById(adminPageModel.LotToCheck.Id)).Returns(lot);
            //Act 
            var result = _userController.AdminPage(adminPageModel);

            //Assert
            Assert.AreEqual(lot.StatusLot,
                AuctionSite.EfStaff.Enum.StatusLotEnum.CheckedWithMistake,
                "StatusLot must become CheckedWithMistake");
            Assert.AreEqual(lot.MistakeAfterCheck, adminPageModel.TextMistake,
                "lot.MistakeAfterCheck must become adminPageModel.TextMistake");
        }
    }
}
