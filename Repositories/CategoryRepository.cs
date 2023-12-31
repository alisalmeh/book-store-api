using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Data;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace AliBookStoreApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreContext _context;

        public CategoryRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDetailsDto>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Select(x => new CategoryDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                })
                .ToListAsync();
            return categories;
        }

        public async Task<CategoryDetailsDto> GetCategoryDetailsById(int id)
        {
            var category = await _context.Categories
                .Where(x => x.Id == id)
                .Select(x => new CategoryDetailsDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                })
                .FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> CreateCategory(CreateCategoryDto model)
        {
            var category = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryDto model, int id)
        {
            var category = new Category()
            {
                Id = id,
                Name = model.Name,
                Description = model.Description
            };

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PartialUpdateCategory(JsonPatchDocument<UpdateCategoryDto> model, int id)
        {
            var category = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return false;
            }

            var updateCategoryDto = await _context.Categories
                .Where(x => x.Id == id)
                .Select(x => new UpdateCategoryDto
                {
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();

            model.ApplyTo(updateCategoryDto);

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveCategory(int id)
        {
            var category = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}