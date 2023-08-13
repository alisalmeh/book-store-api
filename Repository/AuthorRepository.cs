using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliBookStoreApi.Data;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AliBookStoreApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext _context;

        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorDetailsDto>> GetAllAuthors()
        {
            var authors = await _context.Authors.Select(x => new AuthorDetailsDto()
            {
                AuthorId = x.AuthorId,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToListAsync();

            return authors;
        }
    }
}