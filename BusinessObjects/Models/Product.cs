using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Weight { get; set; }
        public virtual Category? Category { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
