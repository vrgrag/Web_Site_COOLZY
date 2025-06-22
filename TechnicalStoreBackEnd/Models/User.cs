using System.ComponentModel.DataAnnotations;

namespace TechnicalStoreBackEnd.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public bool IsAdmin { get; set; } = false;

        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
