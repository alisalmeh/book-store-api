using System.Collections.Generic;
using System.Threading.Tasks;
using AliBookStoreApi.Models;

namespace AliBookStoreApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDetailsDto>> GetAllCategories();
    }
}