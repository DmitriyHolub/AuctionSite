using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendMessage(string recipient, string mail);
        public void ConfirmEmail(string recipient, Guid code,string callbackUrl, string header, string text);

    }
}
