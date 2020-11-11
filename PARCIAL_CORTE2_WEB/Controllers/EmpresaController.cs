

using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using PARCIAL_CORTE2_WEB.Models;

namespace PARCIAL_CORTE2_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController
    {
        private readonly ServicioEmpresa _servicioEmpresa;
        public EmpresaController(CreditoContext contexto)
        {
            _servicioEmpresa = new ServicioEmpresa(contexto);
        }

        [HttpGet]
        private ActionResult<RespuestaConsulta<EmpresaViewModel>> Consultar()
        {
            var peticion = _servicioEmpresa.ConsultarTodos();
            return Ok(peticion);
        }

        // POST: api/Empresa
        [HttpPost]
        public ActionResult<Respuesta<EmpresaViewModel>> Guardar(EmpresaInputModel EmpresaInput)
        {
            Empresa Empresa = MapearEmpresa(EmpresaInput);
            var peticion = _servicioEmpresa.Guardar(Empresa);
            return Ok(peticion);
        }

        private Empresa MapearEmpresa(EmpresaInputModel EmpresaInput)
        {
            Empresa empresa = new Empresa
            {
                CantidadTrabajadores = EmpresaInput.CantidadTrabajadores,
                Nombre = EmpresaInput.EmpresaId,
                ValorActivos = EmpresaInput.ValorActivos,
                EmpresaId = EmpresaInput.EmpresaId
            };
            return empresa;
        }
    }
}