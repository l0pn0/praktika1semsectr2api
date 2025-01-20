using System.ComponentModel.DataAnnotations;

namespace praktika1semsectr2api.Model
{
    public class RegisterModel
    {
        [Key]
        public int id_User { get; set; }
        public string? Name { get; set; }
        public string? Discription { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
