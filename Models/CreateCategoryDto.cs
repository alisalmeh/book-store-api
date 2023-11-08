using System.ComponentModel.DataAnnotations;
using AliBookStoreApi.Validations;

namespace AliBookStoreApi.Models
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [BanKeyword]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "500 character limitation")]
        public string Description { get; set; }
    }
}