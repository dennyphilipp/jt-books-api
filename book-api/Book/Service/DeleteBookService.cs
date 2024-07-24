using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Service
{
    public class DeleteBookService
    {
        private readonly Context _context;

        public DeleteBookService(Context context)
        {
            _context = context;
        }
        internal async Task Execute(int id)
        {
           await _context.Books.Where(b => b.Id == id)
                              .ExecuteDeleteAsync();
        }
    }
}