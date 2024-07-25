using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Persistence;
using book_api.Subject.DTO;
using Microsoft.EntityFrameworkCore;

namespace book_api.Subject.Service
{
    public class UpdateSubjectService
    {
        private readonly Context _context;

        public UpdateSubjectService(Context context)
        {
            _context = context;
        }
        internal async Task Execute(UpdateSubjectDTO dto)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == dto.Id)
            ?? throw new NotFoundException("Assunto não encontrado para atualizar.");

            subject.Description = dto.Description;
            await _context.SaveChangesAsync();
        }
    }
}