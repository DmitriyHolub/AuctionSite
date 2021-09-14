using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSite.EfStaff;
using AuctionSite.Services;
using AuctionSite.EfStaff.Repositories;
namespace TimerHelper
{
    class Checker
    {

        private DateTime XTime = new DateTime(0001, 01, 01,10, 5, 0);
        public void CheckTime(object obj)
        {
            if (DateTime.Now.Hour == XTime.Hour && DateTime.Now.Minute == XTime.Minute)
            {
                var dbContextBuilder = new DbContextOptionsBuilder();
                var connectionstring = dbContextBuilder.
                    UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Auction;Integrated Security=True;");

                var dbContext = new AuctionSiteDbContext(connectionstring.Options);

                var _lotRepository = new LotRepository(dbContext);
                var _userRepository = new UserRepository(dbContext);
                var _emailService = new EmailService();

                var lotService = new LotService(_lotRepository, _emailService);

                lotService.CheckFinishBidding();

                var currencyHelper = new CurrencyHelper(dbContext);

                currencyHelper.GetCurrentCurrencies();
            }
        }
    }
}
