using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    public interface ILotService
    {
        public void CheckFinishBidding();
        public void SendEmailToObserves(long id);
        
    }
}
