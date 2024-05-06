using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Domain.Entites
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductAmout { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}
