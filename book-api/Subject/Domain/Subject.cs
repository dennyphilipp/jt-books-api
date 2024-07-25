using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Subject.Domain
{
    [Table("Assunto")]
    public class Subject
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(20, ErrorMessage = "A Descrição deve ter no máximo 20 caracteres.")]
        public string Description { get; set; }
    }
}