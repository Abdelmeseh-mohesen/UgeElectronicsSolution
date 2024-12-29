using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;
using UgeElectronics.Core.SpecificationHandler;

namespace UgeElectronics.Services
{
    public class SearchService(IGenericRepository<Product> productRepository) : ISearchService
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;

        public Task<IReadOnlyCollection<Product>> FiltertionProducts(string productName, string ?categoryName)
        {

            var spec = new SearchSpecification(productName, categoryName);
            var products = _productRepository.GetAllWithSpecAsync(spec);
            return products;
        }
    }
}