using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity.Basket
{
    public class BasketItems
    {
        public int Id { get; set; } 
        public int productId { get; set; }
       public Product Product { get; set; }

        public int BasketId { get; set; }
        [JsonIgnore]
        public CustomerBasket Basket { get; set; }
        public int Quantity { get; set; }

   


    }
}
