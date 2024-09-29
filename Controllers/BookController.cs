using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        public static List<Book> _books = new List<Book>()
        {
            new Book () {Id = 1 , Title ="Dabbe", Genre = "Horror", ISBN="234324", CopiesAvailable=434, AuthorId=2 },
            new Book () {Id = 2 , Title ="Fırtınaışığı Arşivi", Genre = "Fantasy", ISBN="23", CopiesAvailable=24, AuthorId=1 },
        };
        
        public IActionResult List()
        {

            var yazarlar = AuthorController._authors;
            var books = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                PublishDate = x.PublishDate,
                CopiesAvailable = x.CopiesAvailable,
                AuthorId = x.AuthorId,
                AuthorFullName = yazarlar.FirstOrDefault(y => y.Id == x.AuthorId)?.FullName 


            }).ToList();
            return View(books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar; 
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(BookAddViewModel viewModel)
        {
            var yazarlar = AuthorController._authors;
            
            if (!ModelState.IsValid)
            {
                ViewBag.Author = yazarlar;
                return View(viewModel);
            }


            
            int maxId = _books.Max(x => x.Id);
            
            var newBook = new Book()
            {
                Id = maxId + 1,
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                ISBN = viewModel.ISBN,
                CopiesAvailable = viewModel.CopiesAvailable,
                AuthorId = viewModel.AuthorId,
               
            };
            _books.Add(newBook);
            
            return RedirectToAction("List", "Book");
        }

        
        public IActionResult Delete(int id)
        {
            var book = _books.Find(x => x.Id == id);
            book.IsDeleted = true;
            return RedirectToAction("List", "Book");
        }
        

        public IActionResult Details(int id)
        {

            var book = _books.Find(b => b.Id == id);
            var newBook = new BookDetailViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
                AuthorId = book.AuthorId,


            };
            if (book == null)
            {
                return NotFound();
            }
            return View(newBook);

        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar;
            var book = _books.Find(b => b.Id == id);
            var viewModel = new BookEditViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ISBN = book.ISBN,
                AvailableCopies = book.CopiesAvailable,
                AuthorId = book.AuthorId

            };
            return View(viewModel);

        }
        

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData)
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar;
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var book = _books.Find(x => x.Id == formData.Id);
            book.Title = formData.Title;
            book.Genre = formData.Genre;
            book.ISBN = formData.ISBN;
            book.CopiesAvailable = formData.AvailableCopies;
            book.AuthorId = formData.AuthorId;
            return RedirectToAction("List");
        }
    }
}
