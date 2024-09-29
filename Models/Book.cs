using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        // Book informations...
        public Book()
        {
            PublishDate = DateTime.Now;
        }
        public int Id { get; set; }  
        [Required]
        public string? Title { get; set; }  
        [Required]
        public int AuthorId { get; set; }  
        [Required]
        public string? Genre { get; set; }  
        [Required]
        public DateTime PublishDate { get; set; }  
        [Required]
        public string? ISBN { get; set; }  
        [Required]
        public int CopiesAvailable { get; set; }  

        public bool IsDeleted { get; set; }
        
    }
}
