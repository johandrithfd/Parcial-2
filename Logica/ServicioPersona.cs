using System.Linq;
using System.Collections.Generic;
using System;
using Entidad;
using Datos;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioCredito
    {
        private readonly CreditoContext _contexto;

        public ServicioCredito(CreditoContext contexto)
        {
            _contexto = contexto;
        }

        public Respuesta<Credito> Guardar(Credito Credito)
        {
            Respuesta<Credito> peticion = new Respuesta<Credito>(Credito);
            try
            {
                peticion = EjecutarValidaciones(peticion);
                if (peticion.Elemento != null)
                {
                    peticion = new Respuesta<Credito>(Credito,$"Los datos de {Credito.Nombres} han sido guardados correctamente",false);
                    peticion.Elemento.Apoyo.Fecha = DateTime.Now.ToString();
                    _contexto.Creditos.Add(peticion.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                peticion.Elemento = null;
                peticion.Mensaje = "Error de la aplicación: " + E.Message;
            }
            return peticion;
        }

        public Respuesta<Credito> EjecutarValidaciones(Respuesta<Credito> peticion)
        {
                Credito Credito = peticion.Elemento;
                peticion = BuscarPorIdentificacion(peticion.Elemento.Identificacion);
                if (peticion.Elemento == null)
                {
                    peticion.Elemento = Credito;
                    peticion = ValidarMonto(peticion);
                }
                else
                    peticion = new Respuesta<Credito>(null,"La Credito que intenta guardar ya se encuentra registrada (cédula existente)",true);
            return peticion;
        }
        public Respuesta<Credito> BuscarPorIdentificacion(string Identificacion)
        {
            Respuesta<Credito> peticion = new Respuesta<Credito>(new Credito());
            try
            {
                peticion.Elemento = _contexto.Creditos.Find(Identificacion);
                peticion = (peticion.Elemento == null) ? new Respuesta<Credito>(null,$"La Credito con cédula numero {Identificacion} no se encuentra registrada",true):
                new Respuesta<Credito>(peticion.Elemento,"Credito encontrada",false);
            }
            catch (Exception E)
            {
                peticion = new Respuesta<Credito>(null,"Error de la aplicación: " + E.Message,true);
            }
            return peticion;
        }
        public Respuesta<Credito> ValidarMonto(Respuesta<Credito> peticion)
        {
            decimal Total = TotalizarMonto();
            if (Total + peticion.Elemento.Apoyo.ValorApoyo > 600000000)
                peticion = new Respuesta<Credito>(null,"Se ha superado la suma en conjunto del valor máximo de las ayudas: 600.000.000",true);
            return peticion;
        }
        public RespuestaConsulta<Credito> ConsultarTodos()
        {
            RespuestaConsulta<Credito> peticion = new RespuestaConsulta<Credito>();
            try
            {
                peticion.Elementos = _contexto.Creditos.Include(p => p.Apoyo).ToList();
                peticion = (peticion.Elementos.Count != 0)? 
                new RespuestaConsulta<Credito>(peticion.Elementos,"Consulta realizada con éxito",false):
                new RespuestaConsulta<Credito>(new List<Credito>(),"No se han encontrado Creditos registradas",true);
            }
            catch (Exception e)
            {
                peticion = new RespuestaConsulta<Credito>(new List<Credito>(),"Error: " + e.Message,true);
            }
            return peticion;
        }
        public decimal TotalizarMonto()
        {
            return _contexto.Creditos.Sum(p=>p.Apoyo.ValorApoyo);
        }
    }
}