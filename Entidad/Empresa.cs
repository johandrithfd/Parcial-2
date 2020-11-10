using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Empresa
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string EmpresaId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Nombre { get; set; }
        [Column(TypeName = "int")]
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorActivos { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Tipo { get; set; }

        public virtual Credito Credito { get; set; }
    }
}