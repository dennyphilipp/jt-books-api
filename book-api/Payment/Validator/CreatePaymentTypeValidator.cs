using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Payment.DTO;

namespace book_api.Payment.Validator
{
    public class CreatePaymentTypeValidator
    {
        public CreatePaymentTypeValidator(CreatePaymentTypeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            throw new InvalidFieldException("Informe o campo Nome.");
        }
    }
}