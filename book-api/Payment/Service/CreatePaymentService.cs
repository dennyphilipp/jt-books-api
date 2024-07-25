using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Payment.Service
{
    using System.Threading.Tasks;
    using book_api.Payment.Domain;
    using book_api.Payment.DTO;
    using book_api.Persistence;

    public class CreatePaymentService
    {
        private readonly Context _context;

        public CreatePaymentService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(CreatePaymentDTO dto)
        {
            var payment = new Payment
            {
                BookId = dto.BookId,
                TypeId = dto.TypeId,
                Value = dto.Value
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
    }

}