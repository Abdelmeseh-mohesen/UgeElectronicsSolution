using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_System.Helpers;
using Sales_System.Repository.AppDbContext;
using System.Security.Claims;
using UgeElectronics.Core.Entity;

namespace UgeElectronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;


        [Authorize(Policy = "Admin")]
        [HttpPost("AddDiscount")]

        public async Task<IActionResult> AddDiscoutAsync(int productId, int? discout)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id==productId);
            if (product != null)
            {
                product.Discount = discout;
                 _context.Update(product);
                await _context.SaveChangesAsync();

                var response = new ApiResponse<Product>(200, "تمت اضافه الخسم ", product);
                return  Ok(response);
            }

            var badrequst = new ApiResponse<Product>(400, "المنتج غير موجود");
            return BadRequest(badrequst);
        }


        [HttpPost("AddDiscountsToAllProducts")]
        public async Task<IActionResult> AddDiscountsToAllProducts(int discout)
        {
            var products = await _context.Products.ToListAsync();
            foreach (var product in products)
            {
                product.Discount = discout;
            
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }         
            return Ok(products);    
        }


        [HttpGet("GetDiscountOfProducts")]

        public async Task<IActionResult> GetDiscountOfProductsAsync(int? discout)
        {
            if (discout.HasValue)
            {
                var products = await _context.Products.Where(p => p.Discount == discout).ToListAsync();
                var response = new ApiResponse<List<Product>>(200, "تم ارجاع المنتجات التي توجد بيها خصومات", products);
                return Ok(response);
            }

            var allproductsHasDiscount = await _context.Products.Where(p => p.Discount.HasValue).ToListAsync();

            return Ok(allproductsHasDiscount);
        }

        [HttpGet("TestRole")]
        public IActionResult TestRole()
        {
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok(new { User.Identity.Name, Roles = roles });
        }

    }
}
