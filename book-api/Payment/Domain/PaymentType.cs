using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_api.Payment.Domain
{
    [Table("TipoPagamento")]
    public class PaymentType
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(40, ErrorMessage = "O Nome do tipo de pagamento deve ter no máximo 40 caracteres.")]
        public string Name { get; set; }
    }
}