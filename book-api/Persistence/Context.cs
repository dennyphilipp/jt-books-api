using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace book_api.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Book.Domain.Book> Books { get; set; }
        public DbSet<Author.Domain.Author> Authors { get; set; }
        public DbSet<Subject.Domain.Subject> Subjects { get; set; }
        public DbSet<Payment.Domain.PaymentType> PaymentTypes { get; set; }
        public DbSet<Payment.Domain.Payment> Payments { get; set; }



        




    }
}