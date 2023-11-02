using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Models
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}