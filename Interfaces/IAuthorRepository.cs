using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Models;

namespace AliBookStoreApi.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorDetailsDto>> GetAllAuthors();
    }
}