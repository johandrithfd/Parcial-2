using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class Abono
    {
        [Key]
        public int AbonoId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorAbono { get; set; }
        public DateTime Fecha { get; set; }
        public int CreditoId { get; set; }

    }
}
