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
                string respuestaActualizar = ActualizarCredito(Abono);
                if(respuestaActualizar.Equals("Execede"))
                {
                    respuesta.Mensaje = "error el valor es excedido al de la deuda";
                    respuesta.Elemento = null;
                }
                else
                {
                    respuesta = new Respuesta<Abono>(Abono, $"Los datos de han sido guardados correctamente", false);
                    _contexto.Abonos.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta.Elemento = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return respuesta;
        }
        public string ActualizarCredito (Abono abono)
        {
            Credito credito = _contexto.Creditos.Find(abono.CreditoId);
            string respuesta = ObtenerRespuestaAbono(credito,abono);
            if(respuesta.Equals("Execede"))
            {
                return "Execede";
            }
            else
            {
                if(respuesta.Equals("Pagado"))
                {
                    credito.Estado = "Pagado"; 
                }
                credito.AbonarCredito(abono.ValorAbono);
                return "Abono Realizado Con exito";
            }
        }
        public string ObtenerRespuestaAbono (Credito credito,Abono abono)
        {
            decimal valor = credito.ValorCredito - abono.ValorAbono;
            if(valor < 0)
            {
                return "Execede";
            }
            else
            {
                if(valor == 0)
                {
                    return "Pagado";
                }
                else
                {
                    return "en deuda";
                }
            }  
        }

        public RespuestaConsulta<Abono> ConsultarTodos(int creditoId)
        {
            RespuestaConsulta<Abono> peticion = new RespuestaConsulta<Abono>();
            try
            {
                peticion.Elementos = _contexto.Abonos.Where(a => a.CreditoId == creditoId).ToList();
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
