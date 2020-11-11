namespace PARCIAL_CORTE2_WEB.Models
{
    public class EmpresaInputModel
    {


        public string EmpresaId { get; set; }

        public string Nombre { get; set; }

        public int CantidadTrabajadores { get; set; }

        public decimal ValorActivos { get; set; }

        public string Tipo { get; set; }
        public virtual Credito Credito { get; set; }
    }
    public class EmpresaViewModel : EmpresaInputModel
    {
        
    }
}