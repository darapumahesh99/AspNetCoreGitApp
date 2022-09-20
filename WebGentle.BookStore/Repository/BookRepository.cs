using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration configuration = null;
        public BookRepository(BookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageID = model.LanguageID,

                TotalPages = model.TotalPages,
                CoverImageUrl = model.CoverImageUrl,
                PdfFileUrl = model.PdfFileUrl,
                UpdatedOn = DateTime.UtcNow
            };

            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    Url = file.Url
                });
            }

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
                        TotalPages = book.TotalPages,
                        CoverImageUrl = book.CoverImageUrl,
                        PdfFileUrl = book.PdfFileUrl
                    });
                }
            }
            return books;
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageID = book.LanguageID,

                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl,
                PdfFileUrl = book.PdfFileUrl
            }).Take(count).ToListAsync();


        }
        public async Task<BookModel> GetBookByID(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageID = book.LanguageID,

                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    ID = g.ID,
                    Name = g.Name,
                    Url = g.Url
                }).ToList(),
                PdfFileUrl = book.PdfFileUrl

            }).FirstOrDefaultAsync();

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
        public string GetAppName()
        {
            return configuration["AppName"] + configuration.GetValue<bool>("Boolean");
        }

    }
}
