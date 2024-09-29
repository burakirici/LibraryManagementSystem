﻿using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        public static List<Author> _authors = new List<Author>()
        {
           new Author{Id = 1, FirstName = "Zeynep", LastName = "KIRICI" , DateOfBirth=new DateTime(1998,6,21) },
           new Author{Id = 2, FirstName = "Burak", LastName = "KIRICI" , DateOfBirth=new DateTime(1996,6,17) },
           new Author{Id = 3, FirstName = "Emre Can", LastName = "TERKAN" , DateOfBirth=new DateTime(1998,3,30) }
        };



        public IActionResult List()
        {
            var author = _authors.Where(y => y.IsDeleted == false).Select(y => new AuthorListViewModel
            {
                Id = y.Id,
                FirstName = y.FirstName,
                LastName = y.LastName,
                DateOfBirth = y.DateOfBirth,

            }).ToList();
            return View(author);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AuthorListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            int maxId = _authors.Max(x => x.Id);
            var newAuthor = new Author
            {
                Id = maxId + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,

            };
            _authors.Add(newAuthor);
            return RedirectToAction("List", "Author");

        }



        public IActionResult Delete(int id)
        {
            var author = _authors.Find(x => x.Id == id);
            author!.IsDeleted = !author.IsDeleted;
            return RedirectToAction("List", "Author");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _authors.Find(x => x.Id == id);
            var viewModel = new AuthorEditViewModel()
            {
                Id = author!.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var author = _authors.Find(x => x.Id == model.Id);
            author!.LastName = model.LastName;
            author.FirstName = model.FirstName;
            author.DateOfBirth = model.DateOfBirth;
            return RedirectToAction("List", "Author");
        }
    }
}
