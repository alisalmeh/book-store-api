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
        [Required(ErrorMessage = "Title is required")]
        [BanKeyword]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [MaxLength(500, ErrorMessage = "500 character")]
        public string Description { get; set; }

        [Range(0, 5000, ErrorMessage = "price should be between 0 and 5000")]
        public float Price { get; set; }
    }
}