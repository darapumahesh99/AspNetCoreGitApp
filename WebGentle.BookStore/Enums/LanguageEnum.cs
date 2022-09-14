using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name="Hindi language")]
        Hindi=1,
        [Display(Name = "English language")]
        English =2,
        [Display(Name = "Urdu language")]
        Urdu =3,
        [Display(Name = "Arabic language")]
        Arabic =3240,
        [Display(Name = "Chinese language")]
        Chinese =453
    }
}
