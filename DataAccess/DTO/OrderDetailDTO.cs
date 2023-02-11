using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class OrderDetailDTO
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
