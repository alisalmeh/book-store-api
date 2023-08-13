using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}