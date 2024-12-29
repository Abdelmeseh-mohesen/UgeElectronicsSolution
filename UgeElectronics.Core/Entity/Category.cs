using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UgeElectronics.Core.Entity
{
    public class Category
    {
        public int Id { get; set; }         
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
