using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Subject.DTO;

namespace book_api.Payment.Extension
{
    public static class PaymentToDTOExtension
    {

        public static PaymentDTO ToDTO(this Domain.Payment payment)
        {
            return new PaymentDTO(payment.Id, payment.TypeId, payment.BookId, payment.Value);
        }

        public static PaymentTableDTO ToTableDTO(this Domain.Payment payment)
        {
            return new PaymentTableDTO(payment.Id, payment.Type.Name, payment.Book.Title, payment.Value);
        }
    }
}