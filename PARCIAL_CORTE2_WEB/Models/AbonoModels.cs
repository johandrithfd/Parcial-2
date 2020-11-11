using System;
using Entidad;

namespace PARCIAL_CORTE2_WEB.Models
{
    public class AbonoInputModel
    {
        public decimal ValorAbono { get; set; }
        public int CreditoId { get; set; }
    }
    public class AbonoViewModel : AbonoInputModel
    {
        public DateTime Fecha { get; set; }
        public int AbonoId { get; set; }

        public AbonoViewModel()
        {

        }
        public AbonoViewModel(Abono Abono)
        {
            ValorAbono = Abono.ValorAbono;
            CreditoId = Abono.CreditoId;
            AbonoId = Abono.AbonoId;
            Fecha = Abono.Fecha;
        }

    }
}