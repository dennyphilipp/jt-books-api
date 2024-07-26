using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Infrastructure.Exception;
using book_api.Subject.DTO;

namespace book_api.Subject.Validator
{
    public class CreateSubjectValidator
    {
        public CreateSubjectValidator(CreateSubjectDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new InvalidFieldException("Informe o campo Descrição.");
        }
    }
}