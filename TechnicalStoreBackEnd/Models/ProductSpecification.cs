namespace TechnicalStoreBackEnd.Models
{
    public class ProductSpecification
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string GroupName { get; set; }     // "Основные", "Экран" и т.д.
        public string AttributeName { get; set; } // "Бренд", "Тип телефона"
        public string AttributeValue { get; set; } // "Xiaomi", "AMOLED"

        public Product Product { get; set; }
    }
}
