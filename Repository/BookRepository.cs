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
                Id = x.BookId,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync();
            return books;
        }

        public async Task<BookDetailsDto> GetBookDetailsById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                        .Select(x => new BookDetailsDto()
                                        {
                                            Id = x.Id,
=======
            var book = await _context.Books.Where(x => x.BookId == id)
                                        .Select(x => new BookDetailsDto()
                                        {
                                            Id = x.BookId,
                                            Title = x.Title,
                                            Description = x.Description,
                                            Price = x.Price
                                        }).FirstOrDefaultAsync();
            return book;
        }

        public async Task<int> CreateBook(CreateBookDto model)
        {
            var book = new Book()
            {
                Price = model.Price,
                Title = model.Title,
                Description = model.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.BookId;
        }

        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            var book = await _context.Books.Where(x => x.BookId == id)
                                .FirstOrDefaultAsync();

            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Price = model.Price;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveBook(int id)
        {
            /* var book = new Book() { Id = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(); */

            var book = await _context.Books.Where(x => x.BookId == id)
                                .FirstOrDefaultAsync();

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}