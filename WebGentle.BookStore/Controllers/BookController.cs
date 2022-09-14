﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            IEnumerable<BookModel> allBooks = await _bookRepository.GetAllBooks();
            return View(allBooks);
        }

        [Route("book-detail/{id}", Name ="BookByID")]
        public async Task<ViewResult> GetBookByID(int id)
        {
            
            //var data =  _bookRepository.GetBookByID(id);
            

            // anonymous data 
            dynamic data = new ExpandoObject();
            data.book= await _bookRepository.GetBookByID(id);
            data.Name = "Mahesh";
            /*Title = data.book.Title;*/
            Title = "ASPNETCORE";
            return View(data);
        }

        public List<BookModel> SearchBook(string name, string authorName)
        {
            return _bookRepository.SearchBook(name, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookID = 0)
        {
            var defaultBook = new BookModel()
            {
                //Language = "English"
            };

            ViewBag.language = new SelectList(await _languageRepository.GetLanguages(), "ID", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookID = bookID;
            Title = "AddNewBook";
            return View(defaultBook);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookID = id });
                }
            }

            ViewBag.language = new SelectList(await _languageRepository.GetLanguages(), "ID", "Name");

            ModelState.AddModelError("", "This is my custom error message");
            return View();
        }
    }
}
