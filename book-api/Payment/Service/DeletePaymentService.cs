using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Payment.Service
{
    public class DeletePaymentService
    {
        private readonly Context _context;

        public DeletePaymentService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(int id)
        {
            await _context.Payments.Where(p => p.Id == id)
                                       .ExecuteDeleteAsync();
        }
    }
}