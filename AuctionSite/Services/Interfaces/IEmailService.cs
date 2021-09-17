using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    interface IEmailService
    {
        public void SendMessage(string recipient, string mail);

    }
}
