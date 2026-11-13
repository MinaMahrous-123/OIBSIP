using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderItemVegetables
    {
        public int Id { get; set; }

        public int OrderItemId { get; set; }

        public int VegetableId { get; set; }
    }
}
