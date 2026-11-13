using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BaseId { get; set; }
        public int SauceId { get; set; }

        public int CheeseId { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; }
    }
}
