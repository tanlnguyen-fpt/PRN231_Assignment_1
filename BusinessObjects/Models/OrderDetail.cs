using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class OrderDetail
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public double? Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
