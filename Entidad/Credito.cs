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
        [Column(TypeName = "nvarchar(20)")]
        public string Estado { get; set; }
        public Credito()
        {
            Estado = "En Deuda";
        }

        public void AbonarCredito(decimal valorAbono)
        {
            ValorCredito = ValorCredito - valorAbono;
        }
    }
}