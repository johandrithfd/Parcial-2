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
        public int CantidadTrabajadores { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorActivos { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Tipo { get; set; }
        public virtual Credito Credito { get; set; }


        public void AsignarTipo()
        {
            decimal salarioMinimo = 877800;
            decimal valorActivoMaximo;
            decimal valorActivoMinimo;
            if ((CantidadTrabajadores >= 1 && CantidadTrabajadores <= 10) )
            {
                valorActivoMaximo = salarioMinimo * 501;
                if (valorActivoMaximo <= ValorActivos)
                {
                    Tipo = "Microempresa";
                }
            }
            if ((CantidadTrabajadores >= 11 && CantidadTrabajadores <= 50))
            {
                valorActivoMaximo = salarioMinimo * 5001;
                valorActivoMinimo = salarioMinimo * 501;
                if (ValorActivos >= valorActivoMinimo && ValorActivos <= valorActivoMaximo )
                {
                    Tipo = "Pequeña Empresa";
                }
            }
            if ((CantidadTrabajadores >= 51 && CantidadTrabajadores <= 200))
            {
                valorActivoMaximo = salarioMinimo * 15000;
                valorActivoMinimo = salarioMinimo * 5001;
                if (ValorActivos >= valorActivoMinimo && ValorActivos <= valorActivoMaximo)
                {
                    Tipo = "Mediana";
                }
            }
        }

        public void AsignarCredito()
        {
            AsignarTipo();
            switch (Tipo)
            {
                case "Microempresa": Credito.ValorCredito = 100000000; break;
                case "Pequeña Empresa": Credito.ValorCredito = 150000000; break;
                case "Mediana": Credito.ValorCredito = 200000000; break;
            }
        }
    }
}