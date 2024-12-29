using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService=favouriteService;
        }

        [HttpPost("switch-favourite/{productId}")]
        public async Task<IActionResult> SwitchFavourite(int productId)
        {
            var result = await _favouriteService.SwitchIsFavourite(productId);

            if ( result )
            {
                return Ok(new { message = "Favourite status switched successfully." });
            }

            return NotFound(new { message = "Product not found." });
        }

        [HttpGet("Favourites")]
        public async Task<IActionResult> GetFavourites()
        {
            var result = await _favouriteService.GetProductIsFavourite();
           return Ok(result);
        }
    }
}
