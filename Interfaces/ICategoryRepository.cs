using System.Collections.Generic;
using System.Threading.Tasks;
using AliBookStoreApi.Models;

namespace AliBookStoreApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDetailsDto>> GetAllCategories();
        Task<CategoryDetailsDto> GetCategoryDetailsById(int id);
        Task<int> CreateCategory(CreateCategoryDto model);
        Task<bool> UpdateCategory(UpdateCategoryDto model, int id);
    }
}