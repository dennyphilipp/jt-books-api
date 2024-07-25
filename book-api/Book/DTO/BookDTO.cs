using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Book.DTO
{
    public record BookDTO(int Id, string Title, string Publischer, int Version, string Year);

}