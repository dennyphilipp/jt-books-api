using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Payment.Service
{
    using System.Threading.Tasks;
    using book_api.Payment.Domain;
    using book_api.Payment.DTO;
    using book_api.Payment.Validator;
    using book_api.Persistence;

    public class CreatePaymentTypeService
    {
        private readonly Context _context;

        public CreatePaymentTypeService(Context context)
        {
            _context = context;
        }

        internal async Task Execute(CreatePaymentTypeDTO dto)
        {
            var validator = new CreatePaymentTypeValidator(dto);
            var paymentType = new PaymentType
            {
                Name = dto.Name
            };

            await _context.PaymentTypes.AddAsync(paymentType);
            await _context.SaveChangesAsync();
        }
    }

}