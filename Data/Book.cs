using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
    }
}