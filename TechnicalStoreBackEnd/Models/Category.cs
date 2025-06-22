namespace TechnicalStoreBackEnd.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty; // 🔹 для поиска

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
