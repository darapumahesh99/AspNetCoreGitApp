using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookByID(int id)
        {
            return DataSource().Where(x=>x.Id==id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => (x.Title.Contains(title) && x.Author.Contains(authorName))).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="a", Author="Mahesh", Description="Description for a"},
                new BookModel(){Id=2, Title="b", Author="Mahesh", Description="Description for b"},
                new BookModel(){Id=3, Title="c", Author="Mahesh", Description="Description for c"},
                new BookModel(){Id=4, Title="d", Author="Mahi", Description="Description for d"},
                new BookModel(){Id=4, Title="e", Author="Mahi", Description="Description for e"}
            };
        }
    }
}
