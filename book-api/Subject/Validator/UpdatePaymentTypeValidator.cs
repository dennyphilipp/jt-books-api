using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Subject.DTO;

namespace book_api.Subject.Validator
{
    public class UpdateSubjectValidator
    {
        public UpdateSubjectValidator(UpdateSubjectDTO dto)
        {
            if (dto.Id <= 0)
                throw new InvalidFieldException("Informe o Id tipo de pagamento.");

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new InvalidFieldException("Informe o campo Descrição.");
        }
    }
}