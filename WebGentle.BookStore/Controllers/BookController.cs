using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore.Controllers
{

    
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            IEnumerable<BookModel> allBooks = await _bookRepository.GetAllBooks();
            return View(allBooks);
        }

        [Route("~/book-detail/{id}", Name ="BookByID")]
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


            // alternative for below is directly getting data from languageRepo: See in views
            /*ViewBag.language = new SelectList(await _languageRepository.GetLanguages(), "ID", "Name");*/

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookID = bookID;
            Title = "AddNewBook";
            return View(defaultBook);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if(bookModel.CoverPhoto != null)
            {
                // Guid to make the image name unique
                string folder = "books/cover/";
                bookModel.CoverImageUrl = await UploadImage(folder, bookModel.CoverPhoto);
                
            }

            if (bookModel.PdfFile != null)
            {
                // Guid to make the image name unique
                string folder = "books/pdf/";
                bookModel.PdfFileUrl = await UploadImage(folder, bookModel.PdfFile);

            }


            if (bookModel.GalleryFiles != null)
            {
                // Guid to make the image name unique
                string folder = "books/gallery/";
                bookModel.Gallery = new List<GalleryModel>();
                foreach (var file in bookModel.GalleryFiles)
                {
                    var gallery = new GalleryModel()
                    {
                        Name = file.FileName,
                        Url= await UploadImage(folder, file)
                };
                    bookModel.Gallery.Add(gallery);
                }

            }

            // to check errors
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookID = id });
                }
            }

            

            ModelState.AddModelError("", "This is my custom error message");
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            
            folderPath +=  Guid.NewGuid().ToString() +"_"+ file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        
    }
}
