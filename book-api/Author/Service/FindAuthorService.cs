using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Author.Extension;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Author.Service
{
    public class FindAuthorService
    {
        private readonly Context _context;

        public FindAuthorService(Context context)
        {
            _context = context;
        }
        internal async Task<AuthorDTO> FindById(int id)
        {
            var author = await _context.Authors.AsNoTracking()
                                           .FirstOrDefaultAsync(b => b.Id == id)
                                           ?? throw new NotFoundException($"O Autor com Id {id} não foi encontrado.");

            return author.ToDTO();
        }

        internal async Task<ICollection<AuthorDTO>> FindAll()
        {
            return await _context.Authors.AsNoTracking()
                                       .OrderBy(o => o.Name)
                                       .Select(s => s.ToDTO())
                                       .ToListAsync();
        }
    }
}