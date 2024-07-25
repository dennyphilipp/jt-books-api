using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Persistence;

namespace book_api.Payment.Service
{
    public class UpdatePaymentTypeService
    {
        private readonly Context _context;

        public UpdatePaymentTypeService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(UpdatePaymentTypeDTO dto)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(dto.Id);
            paymentType.Name = dto.Name;
            await _context.SaveChangesAsync();
        }
    }
}