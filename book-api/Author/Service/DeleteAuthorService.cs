using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Author.Service
{
    public class DeleteAuthorService
    {
        private readonly Context _context;

        public DeleteAuthorService(Context context)
        {
            _context = context;
        }
        internal async Task Execute(int id)
        {
           await _context.Book.Where(b => b.Id == id)
                              .ExecuteDeleteAsync();
        }
    }
}