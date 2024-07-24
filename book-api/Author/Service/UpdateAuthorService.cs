using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Persistence;

namespace book_api.Author.Service
{
    public class UpdateAuthorService
    {
        private readonly Context _context;

        public UpdateAuthorService(Context context)
        {
            _context = context;
        }

        public async Task Execute(UpadteAuthorDTO dto)
        {
            var author = await _context.Authors.FindAsync(dto.Id);
            author.Name = dto.Name;
            await _context.SaveChangesAsync();
        }
    }
}