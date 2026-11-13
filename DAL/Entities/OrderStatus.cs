using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public  enum OrderStatus
    {
        Pending = 1,
        Processing = 3,
        Confirmed = 2,
        OutForDelivery = 4,
        Delivered = 5,
        Cancelled = 6
    }
}
