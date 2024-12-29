using Microsoft.AspNetCore.Http;


namespace UgeElectronics.Core.Dto
{
    public class ProductRequestDto
    {
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        public string ProductImage { get; set; }
        public List<IFormFile> ProductGallery { get; set; } = new();
        public List<string> ProductTags { get; set; } = new();
        public string Description { get; set; }
        public bool BoolTax { get; set; }
        public string TaxClass { get; set; }
        public int CategoryId { get; set; }

    }
}
