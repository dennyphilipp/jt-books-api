using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Author.DTO;
using book_api.Subject.DTO;
using Microsoft.AspNetCore.Components.Web;

namespace book_api.Book.DTO
{
    public record CreateBookDTO(string Title, string Publischer, int Version, string Year, ICollection<int> authors, ICollection<int> subjects);
    
}