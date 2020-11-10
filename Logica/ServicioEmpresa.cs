using System.Linq;
using System.Collections.Generic;
using System;
using Entidad;
using Datos;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioEmpresa
    {
        private readonly CreditoContext _contexto;

        public ServicioEmpresa(CreditoContext contexto)
        {
            _contexto = contexto;
        }

        public Respuesta<Empresa> Guardar(Empresa empresa)
        {
            Respuesta<Empresa> respuesta = new Respuesta<Empresa>();
            try
            {
                empresa.AsignarCredito();
                respuesta = new Respuesta<Empresa>(empresa,$"Los datos de han sido guardados correctamente", false);
                _contexto.Empresas.Add(respuesta.Elemento);
                _contexto.SaveChanges();
            }
            catch (Exception E)
            {
                respuesta.Elemento = null;
                respuesta.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return respuesta;
        }
        public Respuesta<Empresa> BuscarPorIdentificacion(string Identificacion)
        {
            Respuesta<Empresa> peticion = new Respuesta<Empresa>(new Empresa());
            try
            {
                peticion.Elemento = _contexto.Empresas.Find(Identificacion);
                peticion = (peticion.Elemento == null) ? new Respuesta<Empresa>(null,$"La Empresa con numero {Identificacion} no se encuentra registrada",true):
                new Respuesta<Empresa>(peticion.Elemento,"Empresa encontrada",false);
            }
            catch (Exception E)
            {
                peticion = new Respuesta<Empresa>(null,"Error de la aplicación: " + E.Message,true);
            }
            return peticion;
        }
        public RespuestaConsulta<Empresa> ConsultarTodos()
        {
            RespuestaConsulta<Empresa> peticion = new RespuestaConsulta<Empresa>();
            try
            {
                peticion.Elementos = _contexto.Empresas.Include(e => e.Credito).ToList();
                peticion = (peticion.Elementos.Count != 0)? 
                new RespuestaConsulta<Empresa>(peticion.Elementos,"Consulta realizada con éxito",false):
                new RespuestaConsulta<Empresa>(new List<Empresa>(),"No se han encontrado Empresas registradas",true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Empresa>(new List<Empresa>(),"Error: " + e.Message,true);
            }
            return peticion;
        }
    }
}