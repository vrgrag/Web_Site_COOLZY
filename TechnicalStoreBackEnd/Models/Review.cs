using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalStoreBackEnd.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        // Навигационное свойство временно убрано, чтобы не мешало сериализации
        // [ForeignKey("ProductId")]
        // public Product Product { get; set; }

        [Required]
        public int UserId { get; set; }

        // [ForeignKey("UserId")]
        // public User User { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
