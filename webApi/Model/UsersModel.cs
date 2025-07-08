using System.ComponentModel.DataAnnotations;

namespace webApi.Model
{
    public class UsersModel
    {

        [Required]
        [Range(1, int.MaxValue)]        
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string UserName { get; set; }
        [Required]
        [MinLength(7)]
        public string Password { get; set; }

        public string Role { get; set; }
        public bool IsAdmin { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

    }


}
