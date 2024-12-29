using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        // Inject the ProductService via constructor
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        // POST api/product - Create a new product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm]ProductRequestDto productRequestDto)
        {
            if ( !ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await _productService.CreateProductAsync(productRequestDto);
            return Ok(createdProduct);
        }

        // GET api/product - Get all products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }

     
    }
}
