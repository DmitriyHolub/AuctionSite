using AuctionSite.EfStaff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.EfStaff.Enum;
using AuctionSite.Services.Interfaces;
using AuctionSite.EfStaff.Repositories.Interfaces;

namespace AuctionSite.Services
{
    public class LotService: ILotService
    {
        private ILotRepository _lotRepository { get; set; }
        private EmailService _emailService { get; set; }
        
        public LotService(ILotRepository lotRepository,
            EmailService emailService)
        {
            _lotRepository = lotRepository;
            _emailService = emailService;
        }

        public void CheckFinishBidding()
        {
            var expiredLots = _lotRepository.GetExpiredLots(DateTime.Now);

            foreach (var lot in expiredLots)
            {
                var text = string.Empty;

                if (lot.BuyoutPrice==lot.StartPrice)
                {
                    lot.StatusLot = StatusLotEnum.NotSold;

                    _lotRepository.Save(lot);

                    text = $"Dear {lot.UserCreator.Name}. Your lot {lot.LotName} have not been sold. Try Again";
                    _emailService.SendMessage(lot.UserCreator.Email, text);
                }

                lot.StatusLot = StatusLotEnum.Sold;

                _lotRepository.Save(lot);

                text = $"congratulations))). Dear {lot.LastBidUser.Name}. You win the bidding of lot {lot.LotName}" +
                    $" with the price {lot.BuyoutPrice}$";
                _emailService.SendMessage(lot.LastBidUser.Email, text);
            }
        }
        public void SendEmailToObserves(long id)
        {
            var lot = _lotRepository.GetById(id);

            foreach (var Observer in lot.Observers)
            {
                var text = $"The price on lot {lot.LotName} have changed for {lot.BuyoutPrice}";
                _emailService.SendMessage(Observer.Email,text);
            }
        }
        
    }
}
