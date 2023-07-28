using System.Globalization;
using System.Reflection;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Reflection.Metadata;
using System.Data;

using AlquileresPunilla.Comandos.Estadia;
using AlquileresPunilla.Models;
using AlquileresPunilla.Resultados.Estadia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlquileresPunilla.Resultados.Clientes;
using AlquileresPunilla.Resultados.Complejos;

namespace AlquileresPunilla.Controllers;


public class EstadiaController : ControllerBase{
    private readonly AlquilerespunillaContext _context ;
    public  EstadiaController(AlquilerespunillaContext context){
        _context = context;
    }


   [HttpGet]
    [Route("api/Estadia/listaEstados")]
    public async Task<ActionResult<ResultadoEstados>> listaEstado()
    {
        try
        {
            var result = new ResultadoEstados();
            var estados = await _context.Estadoestadia.ToListAsync();
            if (estados != null)
            {
                foreach (var com in estados)
                {
                    var resultAux = new ItemEstado(){
                        IdEstado=com.IdEstadoEstadia,
                        Descripcion = com.Descripcion,

                    };
                    result.listaEstado.Add(resultAux);
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        catch (Exception e)
        {
          return BadRequest("No se puede realizar esta acción");
        }
    }

  [HttpPost]
  [Route("Api/Estadia/CrearPersona")]

  public async Task<ActionResult<ResultadoPersonaPost>> CrearPersona([FromBody] ComandoPersonaPost comando) {
    try
    {
      var provinciaExistente = await _context.Provincias.FirstOrDefaultAsync(p => p.IdProvincia == comando.IdProvincia);
      if (provinciaExistente == null)
      {
        var provincia = new Provincia{
          IdProvincia = comando.IdProvincia,
          Descripcion = comando.Descripcion

      };
      _context.Provincias.Add(provincia);
      };
      var localidadExixtente = await _context.Localidades.FirstOrDefaultAsync(p => p.IdLocalidades == comando.IdLocalidad);
      if (localidadExixtente == null)
      {
        var localidad = new Localidade{
          IdLocalidades = comando.IdLocalidad,
          Descripcion = comando.Descripcion2,
          IdProvicia = comando.IdProvincia 

      };
      _context.Localidades.Add(localidad);
      };
      var persona = new Persona{
        idComplejo = comando.idComplejo,
        Nombre = comando.Nombre,
        Apellido = comando.Apellido,
        IdLocalidad = comando.IdLocalidad,
        Email = comando.Email,
        Telefono = comando.Telefono
      };


      
      _context.Personas.Add(persona);
      await _context.SaveChangesAsync();
      var result = new ResultadoPersonaPost{
        idpersona = persona.Idpersona,
        StatusCode = 200
      };
      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest("Error al crear la Persona");
    }
  }

  [HttpPost]
  [Route("Api/Estadia/CrearEstadia")]

  public async Task<ActionResult<ResultadoEstadiaPost>> CrearEstadia([FromBody] ComandoEstadiaPost comando) {
    try
    {
      var estadia = new Estadia{
        IdPersona = comando.IdPersona,
        Fecha = DateTime.Now,
        FechaEgreso = comando.FechaEgreso,
        FechaIngreso = comando.FechaIngreso,
        CantPersonas = comando.CantPersona,
        Desayuno = comando.Desayuno,
        ImporteTotal = comando.ImporteTotal,
        ImportePendiente=comando.ImportePendiente,
        IdAlojamiento = comando.IdAlojamiento,
        IdEstado = comando.IdEstado
      };
      _context.Estadias.Add(estadia);
      await _context.SaveChangesAsync();
      var result = new ResultadoEstadiaPost{
        Id = estadia.NroEstadia,
        StatusCode = 200
      };
      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest("Error al crear la Persona");
    }
  }

    [HttpGet]
    [Route("api/Estadia/GetTodosClientes/{id}")]
    public async Task<ActionResult<ResultadoListaClientes>> GetTodosLosActivos(int id)
    {
        try
        {
            var result = new ResultadoListaClientes();
            var clientes = await (from e in _context.Personas
                       where e.idComplejo == id
                       select new
                       {
                           IdPersona = e.Idpersona,
                           Nombre = e.Nombre,
                           Apellido = e.Apellido,
                           Email=e.Email,
                           Telefono = e.Telefono,
                       }).ToListAsync();
;
            if(clientes != null)
            {
                foreach (var cli in clientes)
                {
                    var cliente= new cliente(){
                    
                        Idpersona =cli.IdPersona,
                        Nombre =cli.Nombre,
                        Apellido = cli.Apellido,
                        Email= cli.Email,
                        Telefono = cli.Telefono,

                    };
                    result.listaClientes.Add(cliente);
                }

                return result;

            }
            else
            {

                return result;

            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al obtener el usuario");
        }

    }

    [HttpGet]
    [Route("api/Estadia/GetEstadiasXEstado/{idEstado}/{idComplejo}")]
    public async Task<ActionResult<ResultadoListaEstadiaXEstados>> GetEstadiasXEstado(int idEstado, int idComplejo)
    {
        try
        {
            var result = new ResultadoListaEstadiaXEstados();
            var estadias = await (from e in _context.Estadias
                            join l in _context.Alojamientos on e.IdAlojamiento equals l.IdAlojamientos
                            join p in _context.Personas on e.IdPersona equals p.Idpersona
                            where e.IdEstado == idEstado && l.IdComplejo== idComplejo
                            orderby e.Fecha descending
                            select new
                            {
                                e.NroEstadia,
                                e.Fecha,
                                e.FechaIngreso,
                                e.FechaEgreso,
                                e.CantPersonas,
                                e.Desayuno,
                                e.ImporteTotal,
                                e.ImportePendiente,
                                e.IdPersona,
                                p.Nombre,
                                p.Apellido,
                                l.Descripcion
                            }).ToListAsync();
;
            if(estadias != null)
            {
                foreach (var e in estadias)
                {
                    var estadia= new estadia(){
                    
                        NroEstadia = e.NroEstadia,
                        Fecha = e.Fecha,
                        IdEstado=idEstado,
                        FechaIngreso = e.FechaIngreso,
                        FechaEgreso = e.FechaEgreso,
                        CantPersona= e.CantPersonas,
                        Desayuno = e.Desayuno,
                        ImporteTotal=e.ImporteTotal,
                        IdPersona=e.IdPersona,
                        Nombre=e.Nombre,
                        Apellido=e.Apellido,
                        Descripcion=e.Descripcion,
                        ImportePendiente = e.ImportePendiente


                    };
                    result.listaEstadia.Add(estadia);
                }

                return result;

            }
            else
            {

                return result;

            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al obtener el usuario");
        }
    }

  [HttpPut]
  [Route("Api/Estadia/ModificarEstadia")]
  public async Task<ActionResult<ResultadoEstadiaPost>> ModificarEstadia([FromBody] ComandoEstadiaPost comando) {
    try
    {
      var db = await _context.Estadias.Where(c => c.NroEstadia == comando.NroEstadia).FirstOrDefaultAsync();
      
      if(db != null){

        db.FechaEgreso = comando.FechaEgreso;
        db.FechaIngreso = comando.FechaIngreso;
        db.CantPersonas = comando.CantPersona;
        db.Desayuno = comando.Desayuno;
        db.ImporteTotal = comando.ImporteTotal;
        db.ImportePendiente=comando.ImportePendiente;
        db.IdAlojamiento = comando.IdAlojamiento;
        db.IdEstado = comando.IdEstado;
      
      _context.Estadias.Update(db);
      await _context.SaveChangesAsync();
      var result = new ResultadoEstadiaPost{
        Id = comando.NroEstadia,
        StatusCode = 200
      };
      return Ok(result);
      }
      else{
        var result = new ResultadoEstadiaPost{
          StatusCode=400
        };
        return Ok(result);
      };
    }
    catch (Exception ex)
    {
      return BadRequest("Error al crear la Persona");
    }
  }
  [HttpGet]
  [Route("Api/Estadia/EstadiaxId/{NroEstadia}")]
    public async Task<ActionResult<ResultadoEstadia>> EstadiaxId(int NroEstadia)
    {
        try
        {
            var result = new ResultadoEstadia();
            var estadia = await _context.Estadias.Where(e => e.NroEstadia == NroEstadia).FirstOrDefaultAsync();
            if (estadia != null)
            {
              result.NroEstadia = estadia.NroEstadia;
              result.IdPersona=estadia.IdPersona;
              result.CantPersonas=estadia.CantPersonas;
              result.Desayuno=estadia.Desayuno;
              result.Fecha=estadia.Fecha;
              result.FechaEgreso=estadia.FechaEgreso.Date;
              result.IdAlojamiento=estadia.IdAlojamiento;
              result.IdEstado=estadia.IdEstado;
              result.ImporteTotal=estadia.ImporteTotal;
              result.ImportePendiente= estadia.ImportePendiente;
              result.FechaIngreso=estadia.FechaIngreso.Date;
                
                return result;
            }
            else
            {
                return result;
            }
        }
        catch (Exception e)
        {
          return BadRequest("No se puede realizar esta acción");
        }
    }
   [HttpDelete]
    [Route("Api/Estadia/Eliminar")]
     public async Task<ActionResult<bool>> borrarEstadia (int parametro)
        {

            var db = await _context.Estadias.FindAsync(parametro);
            //var db = await _context.Usuarios.Where(c => c.Equals(parametro)).FirstOrDefaultAsync();

            if(db != null)
            {
                _context.Estadias.Remove(db);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
            
        }
  [HttpPut]
  [Route("Api/Estadia/ModificarPersona")]
  public async Task<ActionResult<ResultadoPersonaPost>> ModificarPersona([FromBody] ComandoPersonaPost comando) {
    try
    {
       var provinciaExistente = await _context.Provincias.FirstOrDefaultAsync(p => p.IdProvincia == comando.IdProvincia);
      if (provinciaExistente == null)
      {
        var provincia = new Provincia{
          IdProvincia = comando.IdProvincia,
          Descripcion = comando.Descripcion

      };
      _context.Provincias.Add(provincia);
      };
      var localidadExixtente = await _context.Localidades.FirstOrDefaultAsync(p => p.IdLocalidades == comando.IdLocalidad);
      if (localidadExixtente == null)
      {
        var localidad = new Localidade{
          IdLocalidades = comando.IdLocalidad,
          Descripcion = comando.Descripcion2,
          IdProvicia = comando.IdProvincia 

      };
      _context.Localidades.Add(localidad);
      };
      var db = await _context.Personas.Where(c => c.Idpersona == comando.IdPersona).FirstOrDefaultAsync();
      
      if(db != null){

        db.Nombre=comando.Nombre;
        db.Apellido=comando.Apellido;
        db.Telefono=comando.Telefono;
        db.Email=comando.Email;
        db.IdLocalidad=comando.IdLocalidad;
        
      
      _context.Personas.Update(db);
      await _context.SaveChangesAsync();
      var result = new ResultadoPersonaPost{
        idpersona = comando.IdPersona,
        StatusCode = 200
      };
      return Ok(result);
      }
      else{
        var result = new ResultadoPersonaPost{
          StatusCode=400
        };
        return Ok(result);
      };
    }
    catch (Exception ex)
    {
      return BadRequest("Error al crear la Persona");
    }
  }
   [HttpGet]
  [Route("Api/Estadia/PersonaxId/{IdPersona}")]
    public async Task<ActionResult<ResultadoCliente>> PersonaxId(int IdPersona)
    {
        try
        {
            var result = new ResultadoCliente();
            var persona = await _context.Personas.Where(e => e.Idpersona == IdPersona).FirstOrDefaultAsync();
            if (persona != null)
            {
              result.IdPersona = persona.Idpersona;
              var localidad = await _context.Localidades.Where(l=> l.IdLocalidades == persona.IdLocalidad).FirstOrDefaultAsync();
              result.IdProvincia=localidad.IdProvicia;
              result.Nombre=persona.Nombre;
              result.Apellido=persona.Apellido;
              result.Telefono=persona.Telefono;
              result.Email=persona.Email;
              result.IdLocalidad=persona.IdLocalidad;

                return result;
            }
            else
            {
                return result;
            }
        }
        catch (Exception e)
        {
          return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpGet]
    [Route("api/Estadia/GetFechas/{idComplejo}")]
    public async Task<ActionResult<ResultadoFechas>> GetFechas(int idComplejo)
    {
        try
        {
            var result = new ResultadoFechas();
            var fecha = await (
            from e in _context.Estadias
            join al in _context.Alojamientos on e.IdAlojamiento equals al.IdAlojamientos
            join c in _context.Complejos on al.IdComplejo equals c.IdComplejo
            where c.IdComplejo == idComplejo
            select new { e.FechaIngreso, e.FechaEgreso,al.Descripcion}
        ).ToListAsync();
;
            if(fecha != null)
            {
                foreach (var e in fecha)
                {
                    var fechas= new fecha(){
                      Descripcion=e.Descripcion,
                      FechaEgreso=e.FechaEgreso,
                      FechaIngreso=e.FechaIngreso
                    };
                    result.listaFechas.Add(fechas);
                }

                return result;

            }
            else
            {

                return result;

            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al obtener el usuario");
        }
    }
     [HttpGet]
    [Route("api/Estadia/GetFechasXalojamiento/{idAlojamiento}/{idComplejo}")]
    public async Task<ActionResult<ResultadoFechas>> GetFechas(int idAlojamiento,int idComplejo)
    {
        try
        {
            var result = new ResultadoFechas();
            var fecha = await (
            from e in _context.Estadias
            join al in _context.Alojamientos on e.IdAlojamiento equals al.IdAlojamientos
            join c in _context.Complejos on al.IdComplejo equals c.IdComplejo
            where c.IdComplejo == idComplejo && al.IdAlojamientos == idAlojamiento
            select new { e.FechaIngreso, e.FechaEgreso }
        ).ToListAsync();
;
            if(fecha != null)
            {
                foreach (var e in fecha)
                {
                    var fechas= new fecha(){
                      FechaEgreso=e.FechaEgreso,
                      FechaIngreso=e.FechaIngreso
                    };
                    result.listaFechas.Add(fechas);
                }

                return result;

            }
            else
            {

                return result;

            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al obtener el usuario");
        }
    }
     [HttpGet]
    [Route("api/Estadia/GetEstadias")]
    public async Task<ActionResult<ResultadoEstadias>> GetEstadias([FromQuery] int idComplejo, [FromQuery] int pageNumber)
    {
        try
        {
            var result = new ResultadoEstadias();
            var estadias = await (from e in _context.Estadias
                            join es in _context.Estadoestadia on e.IdEstado equals es.IdEstadoEstadia
                            join l in _context.Alojamientos on e.IdAlojamiento equals l.IdAlojamientos
                            join p in _context.Personas on e.IdPersona equals p.Idpersona
                            where  l.IdComplejo== idComplejo
                            orderby e.Fecha descending
                            select new
                            {
                                e.NroEstadia,
                                e.Fecha,
                                e.IdEstado,
                                Estado =es.Descripcion,
                                e.FechaIngreso,
                                e.FechaEgreso,
                                e.CantPersonas,
                                e.Desayuno,
                                e.ImporteTotal,
                                e.ImportePendiente,
                                e.IdPersona,
                                p.Nombre,
                                p.Apellido,
                                l.Descripcion
                            }).ToListAsync();
;
            if(estadias != null)
            {
                foreach (var e in estadias)
                {
                    var estadia= new est(){
                    
                        NroEstadia = e.NroEstadia,
                        Fecha = e.Fecha,
                        IdEstado=e.IdEstado,
                        Estado = e.Estado,
                        FechaIngreso = e.FechaIngreso,
                        FechaEgreso = e.FechaEgreso,
                        CantPersona= e.CantPersonas,
                        Desayuno = e.Desayuno,
                        ImporteTotal=e.ImporteTotal,
                        ImportePendiente =e.ImportePendiente,
                        IdPersona=e.IdPersona,
                        Nombre=e.Nombre,
                        Apellido=e.Apellido,
                        Descripcion=e.Descripcion


                    };
                    result.listaEstadia.Add(estadia);
                }

                return result;

            }
            else
            {

                return result;

            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al obtener el usuario");
        }
    }

  
}
