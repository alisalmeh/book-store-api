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

    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorRepository _authorsRepository;

        public AuthorsController(
            ILogger<AuthorsController> logger,
            IAuthorRepository AuthorsRepository)
        {
            _authorsRepository = AuthorsRepository;
            _logger = logger;
        }

        // route: api/Author
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorsRepository.GetAllAuthors();
            return Ok(authors);
        }
    }
}