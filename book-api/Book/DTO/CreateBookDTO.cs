using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace book_api.Book.DTO
{
    public record CreateBookDTO(string Title, string Publischer, int Version, string Year);
    
}