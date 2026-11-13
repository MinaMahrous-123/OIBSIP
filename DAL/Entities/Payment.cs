using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string TransactionId { get; set; }
        public PaymentStatus Status { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
