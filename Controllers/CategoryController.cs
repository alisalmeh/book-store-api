using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Interfaces;
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
    }
}