using System.ComponentModel.DataAnnotations;

namespace UgeElectronics.Dtos.BasketDto
{
    public class BasketItemsDto
    {
        public int Id { get; set; }

        public string Category { get; set; }
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.1, double.MaxValue)]
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public List<string> ProductGallery { get; set; } = new();
        public List<string> ProductTags { get; set; } = new();
        public string Description { get; set; }
        public bool BoolTax { get; set; }
        public string TaxClass { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

    }
}
