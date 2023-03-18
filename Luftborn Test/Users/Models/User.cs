using System.ComponentModel.DataAnnotations;

namespace Luftborn_Test.Users.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
