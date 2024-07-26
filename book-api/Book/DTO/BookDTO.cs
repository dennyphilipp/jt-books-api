using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Subject.DTO;

namespace book_api.Book.DTO
{
    public record BookDTO(int Id, string Title, string Publischer, int Version, string Year, ICollection<int> authors, ICollection<int> subjects);

}