using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Payment.DTO;
using book_api.Persistence;

namespace book_api.Payment.Validator
{
    public class CreatePaymentValidator
    {
        public CreatePaymentValidator(CreatePaymentDTO dto, Context context)
        {
            if (dto.TypeId <= 0)
                throw new InvalidFieldException("Informe o Tipo de Pagamento.");

            if (dto.BookId <= 0)
                throw new InvalidFieldException("Informe o Livro.");

            if (dto.Value <= 0)
                throw new InvalidFieldException("Informe o Valor.");

            var paymentExists = context.Payments.Where(p => p.BookId == dto.BookId)
                                          .Where(p => p.TypeId == dto.TypeId)
                                          .Any();

            if (paymentExists)
                throw new InvalidFieldException("Já existe um Pagamento para o mesmo Livro e Tipo.");

        }
    }
}