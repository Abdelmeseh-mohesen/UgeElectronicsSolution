using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Core.Services
{
    public interface IProductService
    {
        public Task<Product> CreateProductAsync(ProductRequestDto product);
        public Task<List<Product>>GetAllProductAsync();   
    }
}
