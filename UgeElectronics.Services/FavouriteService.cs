using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Services
{
    public class FavouriteService(IGenericRepository<Product> productRepository) : IFavouriteService
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;

        public async Task<IReadOnlyCollection<Product>> GetProductIsFavourite()
        {
           var productIsFavourite= await _productRepository.GetTableNoTracking().Where(p=>p.isFavourite==true).ToListAsync();  
            return productIsFavourite;  
        }

        public async Task<bool> SwitchIsFavourite(int productId)
        {
            var productExisting = await _productRepository.GetByIdAsync(productId);

            productExisting.isFavourite =!productExisting.isFavourite;  

            await _productRepository.UpdateAsync(productExisting);
            
            return true;
        }
    }
}
