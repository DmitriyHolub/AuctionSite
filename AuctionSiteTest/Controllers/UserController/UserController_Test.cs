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

namespace AuctionSiteTest.Controllers.UserController
{
    //class UserController_Test
    //{
    //    UserLoginModel userLoginModel = new UserLoginModel() { Login = "111", Password = "111" };
    //    Mock<IUserRepository> _userRepository;
    //    Mock<ITypeLotRepository> _typeLotRepository;
    //    Mock<ILotRepository> _lotRepository;
    //    Mock<IMapper> _mapper;
    //    Mock<IUserService> _userService;
    //    Mock<IEmailService> _emailService;
    //    AuctionSite.Controllers.UserController _userController;
    //    public void SetUp()
    //    {
    //        _userRepository = new Mock<IUserRepository>();
    //        _typeLotRepository = new Mock<ITypeLotRepository>();
    //        _lotRepository = new Mock<ILotRepository>();
    //        _userService = new Mock<IUserService>();
    //        _mapper = new Mock<IMapper>();
    //        _emailService = new Mock<IEmailService>();
    //        _userController =
    //            new AuctionSite.Controllers.UserController(_userRepository.Object,
    //            _typeLotRepository.Object,
    //            _lotRepository.Object,
    //            _mapper.Object,
    //            _userService.Object,
    //            _emailService.Object);
    //    }
    //    [Test]
    //    public void GetModelStateAddModelErrorIfUserNull()
    //    {
    //        //Preparing  
    //        var user = _userRepository.Setup(x => x.
    //        GetByLoginAndPassword(userLoginModel.Login, userLoginModel.Password)).Returns(null as User);
                
    //        //Act 
    //        var answer = _userController.Login(userLoginModel);
            
    //        //Assert

    //    }
    //}
}
