using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace book_api.Book.Domain
{
    [Table("Livro")]
    public class Book
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Titulo")]
        [MaxLength(40, ErrorMessage = "O Título deve ter no máximo 40 caracteres.")]
        public string Title { get; set; }

        [Column("Editora")]
        [MaxLength(40, ErrorMessage = "A Editora deve ter no máximo 40 caracteres.")]
        public string Publisher { get; set; }

        [Column("Edicao")]
        public int Version { get; set; }

        [Column("AnoPublicacao")]
        [Length(4, 4, ErrorMessage = "O Ano de lançamento deve ter 4 digitos.")]
        [MaxLength(4, ErrorMessage = "O Ano de publicação deve ter no máximo 4 dígitos.")]
        public string Year { get; set; }

        public virtual ICollection<Author.Domain.Author> Authors { get; set; }

        public virtual ICollection<Subject.Domain.Subject> Subjects { get; set; }

        public virtual ICollection<Payment.Domain.Payment> Payments { get; set; }



    }
}