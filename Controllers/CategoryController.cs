using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AliBookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoriesRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(
            ICategoryRepository categoriesRepository,
            ILogger<CategoryController> logger)
        {
            _categoriesRepository = categoriesRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoriesRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetailsById(int id)
        {
            var category = await _categoriesRepository.GetCategoryDetailsById(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto model)
        {
            var id = await _categoriesRepository.CreateCategory(model);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto model, int id)
        {
            var result = await _categoriesRepository.UpdateCategory(model, id);

            if (!result)
            {
                return BadRequest("This category id does not exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var result = await _categoriesRepository.RemoveCategory(id);

            if(!result)
            {
                return BadRequest("This category id does not exist!");
            }
            return Ok(result);
        }
    }
}