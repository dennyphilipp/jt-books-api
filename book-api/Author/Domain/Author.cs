using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using book_api.Book.Domain;

namespace book_api.Author.Domain
{
    [Table("Autor")]
    public class Author
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(40, ErrorMessage = "O Nome deve ter no máximo 40 caracteres.")]
        public string Name { get; set; }

        public virtual ICollection<Book.Domain.Book> Books { get; set; }
    }
}