using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity.Order_Aggregation;

namespace UgeElectronics.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.pending;
        public Address ShippingAddress { get; set; }
        public Deliverymethod Deliverymethod { get; set; }
        public ICollection<OrderItem> Items { get; set; }= new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GetTotal()=> SubTotal+Deliverymethod.Cost;
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
