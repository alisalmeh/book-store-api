using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Models
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنید")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}