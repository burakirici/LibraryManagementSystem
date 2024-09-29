namespace LibraryManagementSystem.Models
{
    public class Author
    {
        // Author informations.
        public int Id { get; set; }  
        public string FirstName { get; set; }  
        public string LastName { get; set; }  

        public DateTime DateOfBirth { get; set; } 
        public bool IsDeleted { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
