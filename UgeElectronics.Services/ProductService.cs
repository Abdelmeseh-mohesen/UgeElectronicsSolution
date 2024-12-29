using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Repository;
using UgeElectronics.Core.Services;
using UgeElectronics.Core.SpecificationHandler;

namespace UgeElectronics.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        // Constructor to inject the repository dependency
        public ProductService(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository=productRepository;
            _mapper=mapper;
        }

        // Method to create a product
        public async Task<Product> CreateProductAsync(ProductRequestDto productRequestDto)
        {
          
            var product = _mapper.Map<Product>(productRequestDto);
            await _productRepository.AddAsync(product);
            return product;
        }

        // Method to get all products
        public async Task<List<Product>> GetAllProductAsync()
        {
            var spec =new ProductSpecification();
            var products = await _productRepository.GetAllWithSpecAsync(spec);
            return products.ToList();
        }
    }
}
