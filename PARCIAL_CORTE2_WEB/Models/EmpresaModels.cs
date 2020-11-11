using Entidad;

namespace PARCIAL_CORTE2_WEB.Models
{
    public class EmpresaInputModel
    {
        public string EmpresaId { get; set; }
        public string Nombre { get; set; }
        public int CantidadTrabajadores { get; set; }
        public decimal ValorActivos { get; set; }
    }
    public class EmpresaViewModel : EmpresaInputModel
    {
        public string Tipo { get; set; }
        public  Credito Credito { get; set; }
        public EmpresaViewModel()
        {

        }
        public EmpresaViewModel(Empresa empresa)
        {
            EmpresaId = empresa.EmpresaId;
            Nombre = empresa.Nombre;
            CantidadTrabajadores = empresa.CantidadTrabajadores;
            ValorActivos = empresa.ValorActivos;
            Tipo = empresa.Tipo;
            Credito = empresa.Credito;
        }

    }
}