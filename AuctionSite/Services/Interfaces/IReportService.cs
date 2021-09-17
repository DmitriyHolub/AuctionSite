using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    interface IReportService
    {
        public byte[] GeneratePdfReport(Lot lot, CurrencyEnum currency);
    }
}
