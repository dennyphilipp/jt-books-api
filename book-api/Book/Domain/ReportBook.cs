using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Book.Domain
{
    public class ReportBook
    {
        public Guid Id { get; set; }

        [Column("Autor")]
        public string Author { get; set; }

        [Column("Livro")]
        public string Book { get; set; }

        [Column("Editora")]
        public string Publisher { get; set; }

        [Column("Ano")]
        public string Year { get; set; }

        [Column("Edicao")]
        public int Version { get; set; }

        [Column("Assunto")]
        public string Subject { get; set; }
    }
}