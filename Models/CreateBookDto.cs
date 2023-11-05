using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Validations;

namespace AliBookStoreApi.Models
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "لطفا عنوان کتاب را وارد کنید")]
        [BanKeyword]
        public string Title { get; set; }
        public string Author { get; set; }

        [MaxLength(30, ErrorMessage = "طول توضیحات بیشتر از 30 کرکتر نمیتواند باشد")]
        public string Description { get; set; }

        [Range(1000, 1000000, ErrorMessage = "مبلغ را بین 1000 تا 1000000 وارد کنید")]
        public float Price { get; set; }


    }
}