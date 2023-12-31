using System.Collections.Generic;
using System.Threading.Tasks;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AliBookStoreApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDetailsDto>> GetAllCategories();
        Task<CategoryDetailsDto> GetCategoryDetailsById(int id);
        Task<int> CreateCategory(CreateCategoryDto model);
        Task<bool> UpdateCategory(UpdateCategoryDto model, int id);
        Task<bool> PartialUpdateCategory(JsonPatchDocument<UpdateCategoryDto> model, int id);
        Task<bool> RemoveCategory(int id);
    }
}