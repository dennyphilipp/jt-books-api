using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Author.Extension
{
    public static class ToAuthorExtencion
    {
        public static Domain.Author ToAuthor(this DTO.AuthorDTO dto)
        {
            return new Domain.Author { Name = dto.Name };
        }
    }
}