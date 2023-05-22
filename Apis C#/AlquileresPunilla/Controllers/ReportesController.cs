using AlquileresPunilla.Models;
using AlquileresPunilla.Resultados.Estadia;
using AlquileresPunilla.Resultados.Reporte;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

}
