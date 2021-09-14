using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.EfStaff.Enum
{
    public enum StatusLotEnum
    {
        Active =1,
        Sold = 2,
        NotSold = 3,
        NotChecked = 4,
        CheckedWithMistake = 5
    }
}
