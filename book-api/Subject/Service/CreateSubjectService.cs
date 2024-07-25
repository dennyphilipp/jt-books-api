using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using book_api.Subject.Domain;
using book_api.Subject.DTO;

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
            var subject = new Domain.Subject {
                Description = dto.Description
            };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }
    }
}