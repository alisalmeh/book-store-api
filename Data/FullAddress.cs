using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliBookStoreApi.Data
{
    public class FullAddress
    {
        public int AddressId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}