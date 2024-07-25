using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Payment.DTO;
using book_api.Payment.Extension;
using book_api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace book_api.Payment.Service
{
    public class FindPaymentTypeService
    {
        private readonly Context _context;

        public FindPaymentTypeService(Context context)
        {
            _context = context;
        }
        internal async Task<PaymentTypeDTO> FindById(int id)
        {
            var paymentType = await _context.PaymentTypes.AsNoTracking()
                                           .FirstOrDefaultAsync(b => b.Id == id)
                                           ?? throw new NotFoundException($"O Tipo de Pagamento com Id {id} não foi encontrado.");

            return paymentType.ToDTO();
        }

        internal async Task<ICollection<PaymentTypeDTO>> FindAll()
        {
            return await _context.PaymentTypes.AsNoTracking()
                                       .OrderBy(o => o.Name)
                                       .Select(s => s.ToDTO())
                                       .ToListAsync();
        }
    }
}