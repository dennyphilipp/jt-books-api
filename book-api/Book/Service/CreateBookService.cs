using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using book_api.Author.Extension;
using book_api.Book.DTO;
using book_api.Persistence;
using book_api.Subject.Extension;
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

        internal async Task Execute(CreateBookDTO dto)
        {
            var book = new Domain.Book{
                Publisher = dto.Publischer,
                Title = dto.Title,
                Version = dto.Version,
                Year = dto.Year,
                Authors = dto.authors.Select(s => s.ToAuthor()).ToList(),
                Subjects = dto.subjects.Select(s => s.ToSubject()).ToList()
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
    }
}