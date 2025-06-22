namespace TechnicalStoreBackEnd.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; } // Добавлено для связи с Cart
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
