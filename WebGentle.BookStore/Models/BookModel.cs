using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace WebGentle.BookStore.Models
{
    public class BookModel
    {
        /*[DataType(DataType.DateTime)]*/
        /*[DataType(DataType.Date)]*/
        /*[DataType(DataType.Password)]*/
        /*[DataType(DataType.Currency)]*/
        /*[DataType(DataType.Upload)]*/
        /*[DataType(DataType.EmailAddress)]
        [Display(Name="DateTime")]
        [EmailAddress]*/
        /*public string myField { get; set; }*/
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter your book title")]
        /*[MyCustomValidation("hi",ErrorMessage = "No desired value found")]*/
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your book Author")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Display(Name = "Total pages of book")]
        [Required(ErrorMessage = "Please enter your book total pages")]
        public string TotalPages { get; set; }
        public string CoverImageUrl { get; set; }
        public string PdfFileUrl { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public int LanguageID { get; set; }

        
        public Language Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Display(Name = "Upload your cover photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your pdf file")]
        [Required]
        public IFormFile PdfFile { get; set; }
    }
}
