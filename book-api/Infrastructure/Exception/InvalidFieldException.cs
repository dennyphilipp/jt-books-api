using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Infrastructure.Exception
{
    public class InvalidFieldException : System.Exception
    {
        public InvalidFieldException(string message)
        : base(message)
        {

        }
    }
}