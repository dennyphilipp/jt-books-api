using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Book.Extension;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Service
{
    public class FindBookService
    {
        private readonly Context _context;

        public FindBookService(Context context)
        {
            _context = context;
        }

        internal async Task<BookDTO> FindById(int id)
        {
            var book = await _context.Books.AsNoTracking()
                                           .Include(i => i.Authors)
                                           .Include(i => i.Subjects)
                                           .FirstOrDefaultAsync(b => b.Id == id)
                                           ?? throw new NotFoundException($"O Livro com Id {id} não foi encontrado.");

            return book.ToDTO();
        }

        internal async Task<ICollection<BookTableDTO>> FindAll()
        {
            return await _context.Books.AsNoTracking()
                                       .OrderBy(o => o.Title)
                                       .Select(s => s.ToTableDTO())
                                       .ToListAsync();
        }
    }
}