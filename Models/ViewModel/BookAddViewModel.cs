using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookAddViewModel
    {
        // Adding for book view model.
        public BookAddViewModel()
        {
            PublishDate = DateTime.Now;
        }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int CopiesAvailable { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int AuthorId
        {
            get; set;
        }
    }
}

