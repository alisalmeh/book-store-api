using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Data;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
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
            var categories = await _context.Categories.Select(x => new CategoryDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryDetailsDto> GetCategoryDetailsById(int id)
        {
            var category = await _context.Categories.Where(x => x.Id == id)
                                                        .Select(x => new CategoryDetailsDto()
                                                        {
                                                            Id = x.Id,
                                                            Name = x.Name,
                                                            Description = x.Description,
                                                        }).FirstOrDefaultAsync();
            return category;
        }
    }
}