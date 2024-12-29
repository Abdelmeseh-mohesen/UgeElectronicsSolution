using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity.Basket
{
    public class CustomerBasket
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public List<BasketItems> Items { get; set; } = new List<BasketItems>();
        
    }
}
