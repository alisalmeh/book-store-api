using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}