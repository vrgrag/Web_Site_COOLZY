using System.ComponentModel.DataAnnotations;

namespace TechnicalStoreBackEnd.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string Name { get; set; } = string.Empty;            // 🔹 Название товара
        public string Description { get; set; } = string.Empty;     // 🔹 Описание

        public string Model { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Availability { get; set; } = string.Empty;

        public string? Ram { get; set; }
        public string? Storage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
