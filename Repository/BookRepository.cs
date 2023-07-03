using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Data;
using AliBookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AliBookStoreApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookDetailsDto>> GetAllBooks()
        {
            var books = await _context.Books.Select(x => new BookDetailsDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Amount = x.Amount
            }).ToListAsync();
            return books;
        }

        public async Task<BookDetailsDto> GetBookDetailsById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                        .Select(x => new BookDetailsDto()
                                        {
                                            Id = x.Id,
                                            Title = x.Title,
                                            Description = x.Description,
                                            Amount = x.Amount
                                        }).FirstOrDefaultAsync();
            return book;
        }
    }
}