using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using book_api.Subject.DTO;
using book_api.Subject.Extension;
using Microsoft.EntityFrameworkCore;

namespace book_api.Subject.Service
{
    public class FindSubjectService
    {
        private readonly Context _context;

        public FindSubjectService(Context context)
        {
            _context = context;
        }
        internal async Task<SubjectDTO> FindById(int id)
        {
            var subject = await _context.Subjects.AsNoTracking()
                                           .FirstOrDefaultAsync(b => b.Id == id)
                                           ?? throw new NotFoundException($"O Assunto com Id {id} não foi encontrado.");

            return subject.ToDTO();
        }

        internal async Task<ICollection<SubjectDTO>> FindAll()
        {
            return await _context.Subjects.AsNoTracking()
                                       .OrderBy(o => o.Description)
                                       .Select(s => s.ToDTO())
                                       .ToListAsync();
        }
    }
}