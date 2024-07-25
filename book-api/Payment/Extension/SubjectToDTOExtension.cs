using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Payment.DTO;
using book_api.Subject.DTO;

namespace book_api.Payment.Extension
{
    public static class PaymentTypeToDTOExtension
    {

        public static PaymentTypeDTO ToDTO(this Domain.PaymentType payment)
        {
            return new PaymentTypeDTO(payment.Id, payment.Name);
        }
    }
}