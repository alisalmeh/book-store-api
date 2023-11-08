using System.Collections.Generic;
using System.Threading.Tasks;
using AliBookStoreApi.Models;

namespace AliBookStoreApi.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
        Task<BookDetailsDto> GetBookDetailsById(int id);
        Task<int> CreateBook(CreateBookDto model);
        Task<bool> UpdateBook(int id, UpdateBookDto model);
        Task<bool> RemoveBook(int id);
    }
}