using System.ComponentModel.DataAnnotations;

namespace MessageusApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Navigation properties
        public List<Message> Messages { get; set; } = new List<Message>();

        public Subscription? Subscription { get; set; }
    }
}
