using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class InventoryTransactionsDTO
    {
        public int Id { get; set; }

        public int IngredientId { get; set; }

        public int Quantity { get; set; }

        public bool Type { get; set; }
        public string Reason { get; set; }


    }
}
