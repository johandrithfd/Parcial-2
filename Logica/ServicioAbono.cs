using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidad;

namespace Logica
{
    public class ServicioAbono
    {
        private readonly CreditoContext _contexto;

        public ServicioAbono(CreditoContext contexto)
        {
            _contexto = contexto;
        }
        public Respuesta<Abono> Guardar(Abono Abono)
        {
            Respuesta<Abono> respuesta = new Respuesta<Abono>();
            try
            {
                respuesta = new Respuesta<Abono>(Abono, $"Los datos de han sido guardados correctamente", false);
                _contexto.Abonos.Add(respuesta.Elemento);
                _contexto.SaveChanges();
            }
            catch (Exception E)
            {
                respuesta.Elemento = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return respuesta;
        }
        public void ActualizarCredito (Abono abono)
        {
            Empresa empresa = _contexto.Empresas.Find(abono.CreditoId);
            empresa.Credito.AbonarCredito(abono.ValorAbono);
            
        }

        public RespuestaConsulta<Abono> ConsultarTodos()
        {
            RespuestaConsulta<Abono> peticion = new RespuestaConsulta<Abono>();
            try
            {
                peticion.Elementos = _contexto.Abonos.ToList();
                peticion = (peticion.Elementos.Count != 0) ?
                new RespuestaConsulta<Abono>(peticion.Elementos, "Consulta realizada con éxito", false) :
                new RespuestaConsulta<Abono>(new List<Abono>(), "No se han encontrado Abonos registradas", true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Abono>(new List<Abono>(), "Error: " + e.Message, true);
            }
            return peticion;
        }
    }
}
