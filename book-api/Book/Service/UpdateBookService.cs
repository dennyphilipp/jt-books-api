using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Service
{
    public class UpdateBookService
    {
        private readonly Context _context;

        public UpdateBookService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(UpdateBookDTO dto)
        {
            var book = await _context.Book.FirstAsync(b => b.Id == dto.Id);
            book.Publisher = dto.Publischer;
            book.Title = dto.Title;
            book.Version = dto.Version;
            book.Year = dto.Year;
            await _context.SaveChangesAsync();
        }
    }
}