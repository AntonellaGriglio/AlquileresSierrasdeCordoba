using AlquileresPunilla.Models;
using AlquileresPunilla.Resultados.Reporte;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace AlquileresPunilla.Controllers;

[ApiController]
public class ReportesController : ControllerBase
{
    private readonly AlquilerespunillaContext _context ;
    public  ReportesController(AlquilerespunillaContext context){
        _context = context;
    }
    
    [HttpGet]
    [Route("api/Reporte/GetEstadiasMañana/{idComplejo}")]
    public async Task<ActionResult<ResultadoEstadiaManiana>> GetEstadiasXEstado(int idComplejo)
    {
        try
        {
            DateTime fechaManana = DateTime.Today.AddDays(1);
            var result = new ResultadoEstadiaManiana();
            var estadias = await (from e in _context.Estadias
                            join l in _context.Alojamientos on e.IdAlojamiento equals l.IdAlojamientos
                            join p in _context.Personas on e.IdPersona equals p.Idpersona
                            join ee in _context.Estadoestadia on e.IdEstado equals ee.IdEstadoEstadia
                            where l.IdComplejo== idComplejo && e.FechaIngreso.Date.Equals(fechaManana)
                            select new
                            {

                                e.NroEstadia,
                                e.Fecha,
                                e.FechaIngreso,
                                e.FechaEgreso,
                                e.CantPersonas,
                                e.Desayuno,
                                e.ImporteTotal,
                                e.IdPersona,
                                p.Nombre,
                                p.Apellido,
                                l.Descripcion,
                               estado=ee.Descripcion
                            }).ToListAsync();
;
            if(estadias != null)
            {
                foreach (var e in estadias)
                {
                    var item= new estadiaManiana(){
                    
                        NroEstadia = e.NroEstadia,
                        Fecha = e.Fecha,
                        Estado=e.estado,
                        FechaIngreso = e.FechaIngreso,
                        FechaEgreso = e.FechaEgreso,
                        CantPersona= e.CantPersonas,
                        Desayuno = e.Desayuno,
                        ImporteTotal=e.ImporteTotal,
                        IdPersona=e.IdPersona,
                        Nombre=e.Nombre,
                        Apellido=e.Apellido,
                        Descripcion=e.Descripcion


                    };
                    result.listaEstadia.Add(item);
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
    [Route("api/Reporte/GetEstadia/{NroEstadia}")]
    public async Task<ActionResult<ResultadoEstadiNro>> getEstadia(int NroEstadia)
    {
        try
        {
            DateTime fechaManana = DateTime.Today.AddDays(1);
            var result = new ResultadoEstadiNro();
            var estadias = await (from e in _context.Estadias
                            join l in _context.Alojamientos on e.IdAlojamiento equals l.IdAlojamientos
                            join c in _context.Complejos on l.IdComplejo equals c.IdComplejo
                            join p in _context.Personas on e.IdPersona equals p.Idpersona
                            join ee in _context.Estadoestadia on e.IdEstado equals ee.IdEstadoEstadia
                            where e.NroEstadia== NroEstadia && e.FechaIngreso.Date.Equals(fechaManana)
                            select new
                            {

                                e.NroEstadia,
                                e.Fecha,
                                e.FechaIngreso,
                                e.FechaEgreso,
                                e.CantPersonas,
                                e.Desayuno,
                                e.ImporteTotal,
                                e.IdPersona,
                                p.Email,
                                p.Telefono,
                                c.NombreComplejo,
                                p.Nombre,
                                p.Apellido,
                                l.Descripcion,
                               estado=ee.Descripcion
                            }).ToListAsync();
;
            if(estadias != null)
            {
                foreach (var e in estadias)
                {
                    var item= new ResultadoEstadiNro(){
                    
                        NroEstadia = e.NroEstadia,
                        Fecha = e.Fecha,
                        Estado=e.estado,
                        Email=e.Email,
                        Telefono=e.Telefono,
                        FechaIngreso = e.FechaIngreso,
                        FechaEgreso = e.FechaEgreso,
                        CantPersona= e.CantPersonas,
                        Desayuno = e.Desayuno,
                        ImporteTotal=e.ImporteTotal,
                        IdPersona=e.IdPersona,
                        Nombre=e.Nombre,
                        Apellido=e.Apellido,
                        Descripcion=e.Descripcion,
                        NombreComplejo = e.NombreComplejo


                    };
                    result = item;
                
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
    [Route("api/Reporte/CantPersonaXprovincia/{idComplejo}")]
    public async Task<ActionResult<ResultadoProvincia>> cantProvincias(int idComplejo)
    {
        try
        {
            var result = new ResultadoProvincia();
           var resultado = _context.Personas
    .Join(_context.Localidades, p => p.IdLocalidad, l => l.IdLocalidades, (p, l) => new { Persona = p, Localidad = l })
    .Join(_context.Provincias, pl => pl.Localidad.IdProvicia, pr => pr.IdProvincia, (pl, pr) => new { PersonaLocalidad = pl, Provincia = pr })
    .Where(plpr => plpr.PersonaLocalidad.Persona.idComplejo == idComplejo)
    .GroupBy(plpr => plpr.Provincia.Descripcion, plpr => plpr.PersonaLocalidad.Persona)
    .Select(g => new { NombreProvincia = g.Key, TotalPersonas = (double)g.Count() })
    .ToList();

var totalPersonas = resultado.Sum(r => r.TotalPersonas);

;
            if(resultado != null)
            {
                foreach (var e in resultado)
                {
                    var item= new lst(){
                        Provincia = e.NombreProvincia,
                        CantPersonas= (e.TotalPersonas / totalPersonas) * 100,
                    };
                    result.lista.Add(item);
                
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
[HttpGet("api/Reporte/DiasOcupadosTotales/{idComplejo}/{anio}")]
public ActionResult<IEnumerable<object>> GetDiasOcupados(int idComplejo, int anio)
{
    try
    {
        var diasOcupados = _context.Estadias
            .Join(_context.Alojamientos, e => e.IdAlojamiento, a => a.IdAlojamientos, (e, a) => new { Estadia = e, Alojamiento = a })
            .Where(x => x.Estadia.IdEstado >= 2 && x.Estadia.IdEstado <= 5 && x.Alojamiento.IdComplejo == idComplejo && x.Estadia.FechaIngreso.Year == anio)
            .GroupBy(x => x.Alojamiento.IdAlojamientos) // Agrupar por el Id del alojamiento
            .Select(g => new { AlojamientoId = g.Key, DiasOcupados = g.Count() }) // Contar los días ocupados por cada alojamiento
            .ToList();

        var result = diasOcupados.Select(d => new { Descripcion = _context.Alojamientos.FirstOrDefault(a => a.IdAlojamientos == d.AlojamientoId)?.Descripcion, DiasOcupados = d.DiasOcupados }).ToList();

        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener los días ocupados");
    }
}
[HttpGet("api/Reporte/DiasOcupadosPorMes/{idComplejo}/{anio}/{mes}")]
public ActionResult<int> GetDiasOcupadosPorMes(int idComplejo, int anio, int mes)
{
    try
    {
        var diasOcupados = _context.Estadias
            .Join(_context.Alojamientos, e => e.IdAlojamiento, a => a.IdAlojamientos, (e, a) => new { Estadia = e, Alojamiento = a })
            .Where(x => x.Estadia.IdEstado >= 2 && x.Estadia.IdEstado <= 5 && x.Alojamiento.IdComplejo == idComplejo && x.Estadia.FechaIngreso.Year == anio && x.Estadia.FechaIngreso.Month == mes)
            .GroupBy(x => x.Alojamiento.IdAlojamientos) // Agrupar por el Id del alojamiento
            .Select(g => new { AlojamientoId = g.Key, DiasOcupados = g.Count() }) // Contar los días ocupados por cada alojamiento
            .ToList();

        var result = diasOcupados.Select(d => new { Descripcion = _context.Alojamientos.FirstOrDefault(a => a.IdAlojamientos == d.AlojamientoId)?.Descripcion, DiasOcupados = d.DiasOcupados }).ToList();

        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener los días ocupados");
    }
}


[HttpGet("DiasOcupadosPorEstado/{idComplejo}")]
        public ActionResult<ResultadoDiasXestado> GetDiasOcupadosPorEstado(int idComplejo)
        {
            try
            {
                var result = _context.Estadias
                    .Join(_context.Alojamientos, e => e.IdAlojamiento, a => a.IdAlojamientos, (e, a) => new { Estadia = e, Alojamiento = a })
                    .Join(_context.Estadoestadia, ea => ea.Estadia.IdEstado, es => es.IdEstadoEstadia, (ea, es) => new { EstadiaAlojamiento = ea, EstadoEstadia = es })
                    .Where(x => x.EstadiaAlojamiento.Estadia.IdEstado >= 1 && x.EstadiaAlojamiento.Estadia.IdEstado <= 5 && x.EstadiaAlojamiento.Alojamiento.IdComplejo == idComplejo)
                    .GroupBy(x => x.EstadoEstadia.Descripcion)
                    .Select(g => new item { DiasOcupados = g.Count(), Estado = g.Key })
                    .ToList();

                var resultado = new ResultadoDiasXestado { lista = result };

                return resultado;
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener los días ocupados por estado");
            }
        }
[HttpGet("DiasOcupadosPorEstado/{idComplejo}/{anio}/{mes}")]
public ActionResult<ResultadoDiasXestado> GetDiasOcupadosMes(int idComplejo, int anio, int mes)
{
    try
    {
        var result = _context.Estadias
            .Join(_context.Alojamientos, e => e.IdAlojamiento, a => a.IdAlojamientos, (e, a) => new { Estadia = e, Alojamiento = a })
            .Join(_context.Estadoestadia, ea => ea.Estadia.IdEstado, es => es.IdEstadoEstadia, (ea, es) => new { EstadiaAlojamiento = ea, EstadoEstadia = es })
            .Where(x => x.EstadiaAlojamiento.Estadia.IdEstado >= 1 && x.EstadiaAlojamiento.Estadia.IdEstado <= 5 && x.EstadiaAlojamiento.Alojamiento.IdComplejo == idComplejo && x.EstadiaAlojamiento.Estadia.FechaIngreso.Year == anio && x.EstadiaAlojamiento.Estadia.FechaIngreso.Month == mes)
            .GroupBy(x => x.EstadoEstadia.Descripcion)
            .Select(g => new item { DiasOcupados = g.Count(), Estado = g.Key })
            .ToList();

        var resultado = new ResultadoDiasXestado { lista = result };

        return resultado;
    }
    catch (Exception ex)
    {
         return BadRequest("Error al obtener los días ocupados por estado");
    }

    
}
[HttpGet("CantidadPersonasTotales/{idComplejo}/{anio}/{mes}")]
public ActionResult<int> GetCantidadPersonasTotales(int idComplejo, int anio, int mes)
{
    try
    {
        var result = _context.Estadias
            .Join(_context.Alojamientos,
                estadia => estadia.IdAlojamiento,
                alojamiento => alojamiento.IdAlojamientos,
                (estadia, alojamiento) => new { Estadia = estadia, Alojamiento = alojamiento })
            .Where(e => e.Alojamiento.IdComplejo == idComplejo && e.Estadia.FechaIngreso.Year == anio && e.Estadia.FechaIngreso.Month == mes)
            .Sum(e => e.Estadia.CantPersonas);

        return result;
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener la cantidad de personas totales");
    }
}
[HttpGet("CantidadPersonasTotales/{idComplejo}/{anio}")]
public ActionResult<IEnumerable<object>> GetCantidadPersonasTotalesXmes(int idComplejo, int anio)
{
    try
    {
        var results = _context.Estadias
            .Join(_context.Alojamientos,
                estadia => estadia.IdAlojamiento,
                alojamiento => alojamiento.IdAlojamientos,
                (estadia, alojamiento) => new { Estadia = estadia, Alojamiento = alojamiento })
            .Where(e => e.Alojamiento.IdComplejo == idComplejo && e.Estadia.FechaIngreso.Year == anio)
            .GroupBy(e => e.Estadia.FechaIngreso.Month)
            .Select(group => new {
                Month = group.Key,
                TotalPersonas = group.Sum(e => e.Estadia.CantPersonas)
            })
            .ToList();

        return results;
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener la cantidad de personas totales");
    }
}


[HttpGet("RecaudacionTotal/{idComplejo}/{anio}")]
public ActionResult<decimal> GetRecaudacionTotal(int idComplejo, int anio)
{
    try
    {
        var result = _context.Estadias
            .Join(_context.Alojamientos,
                estadia => estadia.IdAlojamiento,
                alojamiento => alojamiento.IdAlojamientos,
                (estadia, alojamiento) => new { Estadia = estadia, Alojamiento = alojamiento })
            .Where(e => e.Alojamiento.IdComplejo == idComplejo && e.Estadia.FechaIngreso.Year == anio)
            .Sum(e => e.Estadia.ImporteTotal);

        return result;
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener la recaudación total");
    }
}

[HttpGet("RecaudacionPorAlojamiento/{anio}/{idComplejo}")]
public ActionResult<ResultadoPorAlojamiento> GetRecaudacionPorAlojamiento(int anio, int idComplejo)
{
    try
    {
        var resultado = new ResultadoPorAlojamiento();
        var result = _context.Estadias
            .Where(e => e.FechaIngreso.Year == anio && e.IdAlojamientoNavigation.IdComplejo == idComplejo)
            .GroupBy(e => new { e.IdAlojamiento, e.IdAlojamientoNavigation.Descripcion })
            .Select(g => new ite
            {
                Alojamiento = g.Key.Descripcion,
                ImporteTotal = g.Sum(e => e.ImporteTotal)
            })
            .ToList();

        resultado.lista = result;

        return resultado;
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener la recaudación por alojamiento");
    }
}
[HttpGet("PagosPorTipo/{idComplejo}")]
public ActionResult<ResultadoFormaPago> GetPagosPorTipo(int idComplejo)
{
    try
    {
    var resultado = new ResultadoFormaPago();
    var result = _context.Pagos
        .Join(_context.Formasdepagos, p => p.IdFormaPago, fp => fp.IdFormasDePagos, (p, fp) => new { Pago = p, FormaPago = fp })
        .Join(_context.Detalleestadia, pfp => pfp.Pago.IdPagos, de => de.IdPago, (pfp, de) => new { PagoFormaPago = pfp, DetalleEstadia = de })
        .Join(_context.Estadias, pfpde => pfpde.DetalleEstadia.IdEstadia, e => e.NroEstadia, (pfpde, e) => new { PagoFormaPagoDetalleEstadia = pfpde, Estadia = e })
        .Join(_context.Alojamientos, pfpdee => pfpdee.Estadia.IdAlojamiento, a => a.IdAlojamientos, (pfpdee, a) => new { PagoFormaPagoDetalleEstadiaAlojamiento = pfpdee, Alojamiento = a })
        .Where(x => x.Alojamiento.IdComplejo == idComplejo)
        .GroupBy(x => x.PagoFormaPagoDetalleEstadiaAlojamiento.PagoFormaPagoDetalleEstadia.PagoFormaPago.FormaPago.Descripcion)
        .Select(g => new i
        {
            FormaPago = g.Key,
            TotalPagos = g.Sum(x => x.PagoFormaPagoDetalleEstadiaAlojamiento.PagoFormaPagoDetalleEstadia.DetalleEstadia.IdPagoNavigation.Importe)
        })
        .ToList();

    resultado.lista = result;

    return resultado;
    }
    catch (Exception ex)
    {
        return BadRequest("Error al obtener los pagos por tipo");
    }
}
 [HttpGet("api/Reporte/OcupacionAlojamientos/{idComplejo}/{anio}/{mes}")]
        public ActionResult<ResultadoOcupacion> GetOcupacionAlojamientos(int idComplejo,int anio, int mes)
        {
            try
            {
                string connectionString = "server=localhost;database=alquilerespunilla;uid=root;pwd=42218872Anto"; // Reemplaza esto con tu cadena de conexión
                List<Item> ocupacionAlojamientos = new List<Item>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            a.Descripcion,
                            SUM(DATEDIFF(e.FechaEgreso, e.FechaIngreso)) AS TotalDiasOcupados
                        FROM
                            alquilerespunilla.alojamientos a
                        LEFT JOIN
                            alquilerespunilla.estadias e ON a.idAlojamientos = e.IdAlojamiento
                        WHERE
                            a.IdComplejo = @idComplejo and
                            YEAR(e.FechaIngreso) = @anio
                            AND MONTH(e.FechaIngreso) = @mes
                        GROUP BY
                            a.idAlojamientos,
                            a.Descripcion";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idComplejo", idComplejo);
                        command.Parameters.AddWithValue("@anio", anio);
                        command.Parameters.AddWithValue("@mes", mes);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string descripcion = reader.GetString("Descripcion");
                                int totalDiasOcupados = reader.GetInt32("TotalDiasOcupados");

                                Item ocupacionAlojamiento = new Item
                                {
                                    Descripcion = descripcion,
                                    TotalDiasOcupados = totalDiasOcupados
                                };

                                ocupacionAlojamientos.Add(ocupacionAlojamiento);
                            }
                        }
                    }
                }

                var resultado = new ResultadoOcupacion { lista = ocupacionAlojamientos };
                return resultado;
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener la ocupación de los alojamientos");
            }
        }
     [HttpGet("api/Reporte/OcupacionAlojamientos/{idComplejo}/{anio}")]
        public ActionResult<ResultadoOcupacion> GetOcupacionAlojamientosXmes(int idComplejo,int anio)
        {
            try
            {
                string connectionString = "server=localhost;database=alquilerespunilla;uid=root;pwd=42218872Anto"; // Reemplaza esto con tu cadena de conexión
                List<Item> ocupacionAlojamientos = new List<Item>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            a.Descripcion,
                            SUM(DATEDIFF(e.FechaEgreso, e.FechaIngreso)) AS TotalDiasOcupados
                        FROM
                            alquilerespunilla.alojamientos a
                        LEFT JOIN
                            alquilerespunilla.estadias e ON a.idAlojamientos = e.IdAlojamiento
                        WHERE
                            a.IdComplejo = @idComplejo and
                            YEAR(e.FechaIngreso) = @anio
                        GROUP BY
                            a.idAlojamientos,
                            a.Descripcion";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idComplejo", idComplejo);
                        command.Parameters.AddWithValue("@anio", anio);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string descripcion = reader.GetString("Descripcion");
                                int totalDiasOcupados = reader.GetInt32("TotalDiasOcupados");

                                Item ocupacionAlojamiento = new Item
                                {
                                    Descripcion = descripcion,
                                    TotalDiasOcupados = totalDiasOcupados
                                };

                                ocupacionAlojamientos.Add(ocupacionAlojamiento);
                            }
                        }
                    }
                }

                var resultado = new ResultadoOcupacion { lista = ocupacionAlojamientos };
                return resultado;
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener la ocupación de los alojamientos");
            }
        }
}
