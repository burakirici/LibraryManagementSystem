using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class AuthorAddingViewModel
    {
        [Required]
        public string? FirstName { get; set; }  
        [Required]
        public string? LastName { get; set; }  
        [Required(ErrorMessage = "Please enter a date in Year/Month/Day format.")]

        public DateTime DateOfBirth { get; set; }  
    }
}
