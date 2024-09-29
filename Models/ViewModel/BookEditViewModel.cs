namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookEditViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }  

        public string? Genre { get; set; }  

        public string? ISBN { get; set; }  

        public int AvailableCopies { get; set; }  

        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }

        public string? AuthorFullName { get; set; }
    }
}
