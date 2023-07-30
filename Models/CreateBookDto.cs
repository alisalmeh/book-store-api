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

        [MaxLength(30)]
        public string Description { get; set; }

        [Range(1000, 1000000)]
        public int Price { get; set; }
    }
}