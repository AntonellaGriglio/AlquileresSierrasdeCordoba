
using Microsoft.AspNetCore.Mvc;
using AlquileresPunilla.Models;
using Microsoft.EntityFrameworkCore;

using AlquileresPunilla.Resultados.Complejos;

namespace AlquileresPunilla.Controllers;

public class ComplejoController
{
    private readonly AlquilerespunillaContext context;

    public ComplejoController(AlquilerespunillaContext _context){
        context = _context;
    }

    [HttpGet]
    [Route("api/Complejo/lista")]
    public async Task<ActionResult<ResultadoComplejo>> listaComplejos()
    {
        try
        {
            var result = new ResultadoComplejo();
            var complejos = await context.Complejos.ToListAsync();
            if (complejos != null)
            {
                foreach (var com in complejos)
                {
                    var resultAux = new ItemComplejo(){
                        IdComplejo=com.IdComplejo,
                        NombreComplejo = com.NombreComplejo,
                        LinkFotos = com.LinkFotos
                 
                    };
                    result.listaComplejos.Add(resultAux);
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
          return BadRequestObject("No se puede realizar esta acción");
        }
    }

    private ActionResult<ResultadoComplejo> BadRequestObject(string v)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("api/Alojamiento/lista/{id}")]
    public async Task<ActionResult<ResultadoAlojamiento>> listaAlojamiento(int id)
    {
        try
        {
            var result = new ResultadoAlojamiento();
            var alojamiento = await context.Alojamientos.Where(j => j.IdComplejo.Equals(id)).ToListAsync();
            if (alojamiento != null)
            {
                foreach (var com in alojamiento)
                {
                    var resultAux = new ItemAlojamiento(){
                        IdAlojamiento=com.IdAlojamientos,
                        IdComplejo = com.IdComplejo,
                        Descripcion = com.Descripcion,
                        CantidadPersonas = com.CantidadPersonas,
                        LinkFotos = com.LinkFotos
                 
                    };
                    result.listaAlojamiento.Add(resultAux);
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
          return BadRequestObjectResult("No se puede realizar esta acción");
        }
    }

    private ActionResult<ResultadoAlojamiento> BadRequestObjectResult(string v)
    {
        throw new NotImplementedException();
    }




     [HttpGet]
    [Route("api/Alojamiento/lista/imagenes/{id}")]
    public async Task<ActionResult<ResultadoImgAloj>> ImagenesXAlojamiento(int id)
    {
        try
        {
            var result = new ResultadoImgAloj();
            var imagenesAlojamientos = await context.ImagenesAlojamientos.Where(j => j.idAlojamiento.Equals(id)).ToListAsync();
            if (imagenesAlojamientos != null)
            {
                foreach (var com in imagenesAlojamientos)
                {
                    var resultAux = new Imagenes(){
                        idAlojamiento=com.idAlojamiento,
                        idImagenes=com.idImagenes,
                        
                        LinkFotos = com.LinkFotos
                 
                    };
                    result.listaImagenes.Add(resultAux);
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
          return BadHttpRequestException("No se puede realizar esta acción");
        }
    }

    private ActionResult<ResultadoImgAloj> BadHttpRequestException(string v)
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    [Route("api/Complejo/getById/{id}")]
    public async Task<ActionResult<RtaComplejo>> getUbyId(int id)
    {
        try
        {
            var result = new RtaComplejo();
            var complejo = await context.Complejos.Where(c => c.IdComplejo.Equals(id)).FirstOrDefaultAsync();

            if (complejo != null)
            {
                result.IdComplejo = complejo.IdComplejo;
                result.NombreComplejo = complejo.NombreComplejo;
                
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    private ActionResult<RtaComplejo> BadRequest(string v)
    {
        throw new NotImplementedException();
    }
}
