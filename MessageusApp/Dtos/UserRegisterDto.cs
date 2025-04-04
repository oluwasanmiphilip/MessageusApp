using System.ComponentModel.DataAnnotations;

namespace MessageusApp.Dtos
{
    public class UserRegisterDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty; // Not storing hash in DTO
    }
}
