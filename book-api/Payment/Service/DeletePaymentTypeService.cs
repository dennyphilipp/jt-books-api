using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Payment.Service
{
    public class DeletePaymentTypeService
    {
        private readonly Context _context;

        public DeletePaymentTypeService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(int id)
        {
            await _context.PaymentTypes.Where(p => p.Id == id)
                                       .ExecuteDeleteAsync();
        }
    }
}