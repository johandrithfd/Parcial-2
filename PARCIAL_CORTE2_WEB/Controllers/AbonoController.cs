using System;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using PARCIAL_CORTE2_WEB.Models;

namespace PARCIAL_CORTE2_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonoController : ControllerBase
    {
        private readonly ServicioAbono _servicioAbono;
        public AbonoController(CreditoContext contexto)
        {
            _servicioAbono = new ServicioAbono(contexto);
        }
        [HttpGet]
        public ActionResult<RespuestaConsulta<AbonoViewModel>> Consultar()
        {
            var peticion = _servicioAbono.ConsultarTodos();
            return Ok(peticion);
        }

        // POST: api/Abono
        [HttpPost]
        public ActionResult<Respuesta<AbonoViewModel>> Guardar(AbonoInputModel AbonoInput)
        {
            Abono Abono = MapearAbono(AbonoInput);
            var peticion = _servicioAbono.Guardar(Abono);
            return Ok(peticion);
        }

        private Abono MapearAbono(AbonoInputModel AbonoInput)
        {
            Abono Abono = new Abono
            {
                CreditoId = AbonoInput.CreditoId,
                ValorAbono = AbonoInput.ValorAbono,
                Fecha = DateTime.Now,
            };
            return Abono;
        }

    }
}