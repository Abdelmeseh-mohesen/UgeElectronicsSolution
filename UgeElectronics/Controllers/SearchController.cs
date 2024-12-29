using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UgeElectronics.Core.Services;

namespace UgeElectronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ISearchService searchService) : ControllerBase
    {
        private readonly ISearchService _searchService = searchService;


        [HttpGet("Filteration")]
        public   async Task<IActionResult> Filteration(string productName , string? categoryName)
        {
        
        var products= await _searchService.FiltertionProducts(productName, categoryName); 
         return Ok(products);
        
        }



    }


}
