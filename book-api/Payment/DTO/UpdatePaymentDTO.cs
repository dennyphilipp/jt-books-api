using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Payment.DTO
{
    public record UpdatePaymentDTO(int Id, int TypeId, int BookId, decimal Value);
}