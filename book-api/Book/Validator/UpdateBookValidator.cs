using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Infrastructure.Exception;

namespace book_api.Book.Validator
{
    public class UpdateBookValidator
    {
        public UpdateBookValidator(UpdateBookDTO dto)
        {
            if (dto.Id <= 0)
                throw new InvalidFieldException("Informe o Id do livro.");

            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new InvalidFieldException("Informe o Títulio.");

            if (string.IsNullOrWhiteSpace(dto.Publischer))
                throw new InvalidFieldException("Informe a Editora.");

            if (dto.Version <= 0)
                throw new InvalidFieldException("Informe a Edição.");

            if (string.IsNullOrWhiteSpace(dto.Year))
                throw new InvalidFieldException("Informe o ano.");
            else if (dto.Year.Length < 4)
                throw new InvalidFieldException("Informe o ano com 4 dígitos.");

            if (dto.Authors is null)
                throw new InvalidFieldException("Inform os Autores.");

            if (dto.Subjects is null)
                throw new InvalidFieldException("Inform os Assuntos.");

        }
    }
}