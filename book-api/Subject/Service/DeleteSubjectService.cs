using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Subject.Service
{
    public class DeleteSubjectService
    {
        private readonly Context _context;

        public DeleteSubjectService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(int id)
        {
            await _context.Subjects.Where(p => p.Id == id)
                                       .ExecuteDeleteAsync();
        }
    }
}