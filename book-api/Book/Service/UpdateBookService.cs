using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Book.Validator;
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
            var validator = new UpdateBookValidator(dto);

            var book = await _context.Books.Include(i => i.Authors)
                                    .Include(i => i.Subjects)
                                    .FirstAsync(b => b.Id == dto.Id);
            var authors = await GetAuthors(dto.Authors);
            var subjects = await GetSubjects(dto.Subjects);

            book.Publisher = dto.Publischer;
            book.Title = dto.Title;
            book.Version = dto.Version;
            book.Year = dto.Year;
            book.Authors = authors;
            book.Subjects = subjects;
            await _context.SaveChangesAsync();
        }

        private async Task<ICollection<Author.Domain.Author>> GetAuthors(ICollection<int> authorsId)
        {
            return await _context.Authors.Where(a => authorsId.Any(x => a.Id == x))
                                        .ToListAsync();
        }

        private async Task<ICollection<Subject.Domain.Subject>> GetSubjects(ICollection<int> subjectsId)
        {
            return await _context.Subjects.Where(a => subjectsId.Any(x => a.Id == x))
                                        .ToListAsync();
        }
    }
}