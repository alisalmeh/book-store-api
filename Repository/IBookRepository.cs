using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Models;

namespace AliBookStoreApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
    }
}