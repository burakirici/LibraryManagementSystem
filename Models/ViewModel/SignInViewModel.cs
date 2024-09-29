using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class SignInViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
