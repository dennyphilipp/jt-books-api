using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Payment.DTO
{
    public record PaymentTableDTO(int Id, string Type, string Book, decimal Value);
}