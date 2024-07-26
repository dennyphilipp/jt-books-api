using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Payment.DTO;

namespace book_api.Payment.Validator
{
    public class UpdatePaymentTypeValidator
    {
        public UpdatePaymentTypeValidator(UpdatePaymentTypeDTO dto)
        {
            if (dto.Id <= 0)
                throw new InvalidFieldException("Informe o Id tipo de pagamento.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new InvalidFieldException("Informe o campo Nome.");
        }
    }
}