using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace book_api.Payment.Domain
{
    public class Payment
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual PaymentType Type { get; set; }

        [Column("Valor")]
        public decimal Value { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book.Domain.Book Book { get; set; }

    }
}