using AuctionSite.EfStaff;
using AuctionSite.EfStaff.Models;
using AuctionSite.EfStaff.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSiteTest.EfStafff.Repositories
{
    class UserRepositoryTest
    {
        UserRepository _userRepository;
        Mock<AuctionSiteDbContext> _dbContext;
        [SetUp]
        public void SetUp()
        {
            _dbContext = new Mock<AuctionSiteDbContext>();
            _userRepository = new UserRepository(_dbContext.Object);
        }

        //[Test]
        //[TestCase("Admin", typeof(User))]
        //public void GetByLogin_TestReturnUser(string login, Type type)
        //{
        //    //Preparing

        //    //Act 
        //   var user = _userRepository.GetByLogin(login);
        //    //Assert
        //    Assert.IsInstanceOf(type, user);
        //}
    }
}
