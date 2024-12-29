using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sales_System.Helpers;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Order_Aggregation;
using UgeElectronics.Core.Identity;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public OrdersController(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(int basketId, string buyerEmail, int deliveryMethods)
        {
            var user = await _userManager.FindByEmailAsync(buyerEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var address = new Core.Entity.Order_Aggregation.Address
            {
                FristName = user.FirstName ?? "Unknown", 
                ListName = user.LastName ?? "Unknown", 
                city = user.City ?? "Unknown",
                Country = user.Country ?? "Unknown",
                street = user.Street ?? "Unknown",
            };

            var order = await _orderService.CreateOrderAsync(basketId, buyerEmail, deliveryMethods, address);

            return Ok(order);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders= await _orderService.GetOrderAsync();
            var response = new ApiResponse<List<Order>>(200, "Get Order list Successfully", orders);
            return Ok(response);
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            var response = new ApiResponse<Order>(200, "Get Order  Successfully", order);
            return Ok(response);
        }


    }
}
