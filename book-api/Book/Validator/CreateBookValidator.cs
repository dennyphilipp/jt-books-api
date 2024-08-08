using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using book_api.Book.DTO;
using book_api.Infrastructure.Exception;

namespace book_api.Book.Validator
{
    public class CreateBookValidator
    {
        public CreateBookValidator(CreateBookDTO dto)
        {
            string pattern = @"^\d+$"; 
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new InvalidFieldException("Informe o Título.");

            if (string.IsNullOrWhiteSpace(dto.Publischer))
                throw new InvalidFieldException("Informe a Editora.");

            if (dto.Version <= 0)
                throw new InvalidFieldException("Informe a Edição.");

            if (string.IsNullOrWhiteSpace(dto.Year))
                throw new InvalidFieldException("Informe o ano.");
            else if (dto.Year.Length < 4)
                throw new InvalidFieldException("Informe o ano com 4 dígitos.");
            else if (!Regex.IsMatch(dto.Year, pattern))
                throw new InvalidFieldException("Informe somente números.");

            if (dto.Authors is null)
                throw new InvalidFieldException("Inform os Autores.");

            if (dto.Subjects is null)
                throw new InvalidFieldException("Inform os Assuntos.");

        }
    }
}