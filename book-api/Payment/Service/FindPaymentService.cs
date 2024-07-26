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
    public class FindPaymentService
    {
        private readonly Context _context;

        public FindPaymentService(Context context)
        {
            _context = context;
        }
        internal async Task<PaymentDTO> FindById(int id)
        {
            var payment = await _context.Payments.AsNoTracking()
                                           .FirstOrDefaultAsync(b => b.Id == id)
                                           ?? throw new NotFoundException($"O Pagamento com Id {id} não foi encontrado.");

            return payment.ToDTO();
        }

        internal async Task<ICollection<PaymentTableDTO>> FindAll()
        {
            return await _context.Payments.AsNoTracking()
                                       .Include(i => i.Type)
                                       .Include(i => i.Book)
                                       .OrderBy(o => o.Book.Title)
                                       .ThenBy(o => o.Type.Name)
                                       .Select(s => s.ToTableDTO())
                                       .ToListAsync();
        }
    }
}