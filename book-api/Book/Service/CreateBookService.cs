using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using book_api.Author.Domain;
using book_api.Author.Extension;
using book_api.Book.DTO;
using book_api.Book.Validator;
using book_api.Persistence;
using book_api.Subject.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace book_api.Book.Service
{
    public class CreateBookService
    {
        private readonly Context _context;
        public CreateBookService(Context context)
        {
            _context = context;
        }

        public async Task Execute(CreateBookDTO dto)
        {
            var validator = new CreateBookValidator(dto);
            var authors = await GetAuthors(dto.Authors);
            var subjects = await GetSubjects(dto.Subjects);

            var book = new Domain.Book{
                Publisher = dto.Publischer,
                Title = dto.Title,
                Version = dto.Version,
                Year = dto.Year,
                Authors = authors,
                Subjects = subjects
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        private async Task<ICollection<Author.Domain.Author>> GetAuthors(ICollection<int> authorsId)
        {
            return await _context.Authors.Where(a => authorsId.Any(x => a.Id == x ))
                                        .ToListAsync();
        }

        private async Task<ICollection<Subject.Domain.Subject>> GetSubjects(ICollection<int> subjectsId)
        {
            return await _context.Subjects.Where(a => subjectsId.Any(x => a.Id == x ))
                                        .ToListAsync();
        }
    }
}