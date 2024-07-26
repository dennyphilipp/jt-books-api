using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using book_api.Subject.DTO;
using book_api.Subject.Validator;

namespace book_api.Subject.Service
{
    public class CreateSubjectService
    {
        private readonly Context _context;

        public CreateSubjectService(Context context)
        {
            _context = context;
        }
        internal async Task Execute(CreateSubjectDTO dto)
        {
            var valitador = new CreateSubjectValidator(dto);
            var subject = new Domain.Subject {
                Description = dto.Description
            };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }
    }
}