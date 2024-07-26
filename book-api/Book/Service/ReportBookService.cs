using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Service
{
    public class ReportBookService
    {
        private readonly Context _context;

        public ReportBookService(Context context)
        {
            _context = context;
        }

        internal async Task Execute()
        {
            var result = await _context.ReportBook.ToListAsync();
        }
    }
}