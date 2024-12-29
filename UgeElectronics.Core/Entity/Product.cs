using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        public int? Discount { get; set; }
        public string ProductImage { get; set; }
        public List<string> ProductGallery { get; set; } = new();
        public List<string> ProductTags { get; set; }= new();
        public string Description { get; set; }
        public bool BoolTax { get; set; }
        public string TaxClass { get; set; }
        public  bool isFavourite {  get; set; } =false;
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Categorys { get; set; }
       
    }

}
