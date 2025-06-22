using System.Collections.Generic;
using TechnicalStoreBackEnd.Models; // ← это ОБЯЗАТЕЛЬНО
using System.Linq;

namespace TechnicalStoreBackEnd.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }

        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? PaymentMethod { get; set; }

        public List<OrderItem> Items { get; set; } = new();

        public decimal TotalAmount => Items?.Sum(i => i.Price * i.Quantity) ?? 0m;
    }
}
