using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;

namespace book_api.Author.Extension
{
    public static class AuthorToDTOExtension
    {

        public static AuthorDTO ToDTO(this Domain.Author author)
        {
            return new AuthorDTO(author.Id, author.Name);
        }
    }
}