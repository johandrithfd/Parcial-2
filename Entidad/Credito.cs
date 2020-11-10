using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Credito
    {
        [Key]
        public int CreditoId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorCredito { get; set; }

        
    }
}