using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            IEnumerable<BookModel> allBooks = _bookRepository.GetAllBooks();
            return View();
        }

        public BookModel GetBookByID(int id)
        {
            return _bookRepository.GetBookByID(id);
        }

        public List<BookModel> SearchBook(string name, string authorName)
        {
            return _bookRepository.SearchBook(name, authorName);
        }
    }
}
