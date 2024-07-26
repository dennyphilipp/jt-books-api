using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Author.Validator;
using book_api.Persistence;

namespace book_api.Author.Service
{
    public class CreateAuthorService
    {
        private readonly Context _context;

        public CreateAuthorService(Context context)
        {
            _context = context;
        }

        public async Task Execute(CreateAuthorDTO dto)
        {
            var validator = new CreateAuthorValidator(dto);
            var author = new Domain.Author
            {
                Name = dto.Name,
            };

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
    }

}