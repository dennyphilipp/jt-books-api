using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Book.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MyProperty { get; set; }
    }
}