using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity.Order_Aggregation
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ProductItemsOrder product { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
    }
}
