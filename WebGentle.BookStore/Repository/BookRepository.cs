using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model. Description,
                Title = model.Title,
                LanguageID = model.LanguageID,
                
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);

            await _context.SaveChangesAsync();

           return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageID = book.LanguageID,
                        
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookByID(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageID = book.LanguageID,
                    
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

        /*private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="a", Author="Mahesh", Description="Description for a", Category="Action", Language="English", TotalPages="300"},
                new BookModel(){Id=2, Title="b", Author="Mahesh", Description="Description for b", Category="Action", Language="English", TotalPages="297"},
                new BookModel(){Id=3, Title="c", Author="Mahesh", Description="Description for c", Category="drama", Language="English", TotalPages="490"},
                new BookModel(){Id=4, Title="d", Author="Mahi", Description="Description for d", Category="romance", Language="English", TotalPages="310"},
                new BookModel(){Id=4, Title="e", Author="Mahi", Description="Description for e", Category="Action", Language="English", TotalPages="529"}
            };
        }*/
    }
}
