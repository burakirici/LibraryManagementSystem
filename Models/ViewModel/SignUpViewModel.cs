using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class SignUpViewModel
    {
        // SignUp's View Model...
        [Required]
        public string FirstName { get; set; } 
        [Required]
        public string LastName { get; set; } 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
