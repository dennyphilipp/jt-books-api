using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Infrastructure.Exception;

namespace book_api.Author.Validator
{
    public class UpdateAuthorValidator
    {
        public UpdateAuthorValidator(UpadteAuthorDTO dto)
        {
            if (dto.Id <= 0)
                throw new InvalidFieldException("Informe o Id tipo de pagamento.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new InvalidFieldException("Informe o campo Nome.");
        }
    }
}