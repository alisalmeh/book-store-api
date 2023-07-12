﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Models;
using AliBookStoreApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AliBookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _booksRepository;

        public BooksController(
            ILogger<BooksController> logger,
            IBookRepository booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookDetailsById(int id)
        {
            var book = await _booksRepository.GetBookDetailsById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
        {
            var id = await _booksRepository.CreateBook(model);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto model)
        {
            var result = await _booksRepository.UpdateBook(id, model);

            if (!result)
            {
                return BadRequest("This book id does not exist!");
            }
            return Ok(result);
        }
    }
}
