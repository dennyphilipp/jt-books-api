using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Infrastructure.Exception;

namespace book_api.Author.Validator
{
    public class CreateAuthorValidator
    {
        public CreateAuthorValidator(CreateAuthorDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            throw new InvalidFieldException("Informe o campo Nome.");
        }
    }
}