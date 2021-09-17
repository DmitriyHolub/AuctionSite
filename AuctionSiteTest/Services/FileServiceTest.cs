using AuctionSite.Services;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSiteTest.Services
{
    class FileServiceTest
    {
        private Mock<IWebHostEnvironment> _webHostEnvironment;
        FileService _fileService;
        [SetUp]
        public void SetUp()
        {
            _webHostEnvironment = new Mock<IWebHostEnvironment>();
            _fileService = new FileService(_webHostEnvironment.Object);
        }
   
        [Test]
        [TestCase(5)]
        public void GetImageUrlTest(long Id)
        {
            //Preparing  
            //Act 
            var answer = _fileService.GetImageUrl(Id);
            //Assert
            Assert.AreEqual(answer, $"/LotImages/{Id}.jpg");

        }
        [Test]
        public void GetPathForImageTest() // Правильность названий????
        {
            //Preparing  
            _webHostEnvironment.Setup(x => x.WebRootPath).Returns("Path");
            //Act 
            var answer = _fileService.GetPathForImage();
            //Assert
            Assert.AreEqual(answer, _fileService.GetfolderPath() + "\\LotImages");
        }
        public void GetFolderPathTest() // rfr????
        {
            //Preparing  
            //Act 
            //Assert
        }
    }
}
