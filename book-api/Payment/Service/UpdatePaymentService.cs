using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Persistence;

namespace book_api.Payment.Service
{
    public class UpdatePaymentService
    {
        private readonly Context _context;

        public UpdatePaymentService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(UpdatePaymentDTO dto)
        {
            var payment = await _context.Payments.FindAsync(dto.Id);
            payment.BookId = dto.BookId;
            payment.TypeId = dto.TypeId;
            payment.Value = dto.Value;
            await _context.SaveChangesAsync();
        }
    }
}