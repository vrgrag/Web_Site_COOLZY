using System.ComponentModel.DataAnnotations;

namespace TechnicalStoreBackEnd.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public int UserId { get; set; }

       public User User { get; set; }
    }
}
