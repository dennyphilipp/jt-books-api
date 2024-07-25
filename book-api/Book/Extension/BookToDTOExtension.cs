using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Domain;
using book_api.Book.DTO;
using Npgsql.Replication;

namespace book_api.Book.Extension
{
    public static class BookToDTOExtension
    {
        
        public static BookDTO ToDTO(this Domain.Book book)
        {
            return new BookDTO(book.Id, book.Title, book.Publisher, book.Version, book.Year);
        }
    }
}