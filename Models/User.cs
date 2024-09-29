using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        // User information is here.
        public User()
        {
            JoinDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }  
        public string PhoneNumber { get; set; }  
        public DateTime JoinDate { get; set; }  

        public string FullName => $"{FirstName} {LastName}";
    }
}
