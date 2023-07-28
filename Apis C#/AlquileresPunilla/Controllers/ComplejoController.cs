
using Microsoft.AspNetCore.Mvc;
using AlquileresPunilla.Models;
using Microsoft.EntityFrameworkCore;

using AlquileresPunilla.Resultados.Complejos;
using MySqlConnector;

namespace AlquileresPunilla.Controllers;

public class ComplejoController
{
    private readonly AlquilerespunillaContext context;
    private readonly string connectionString = "server=localhost;database=alquilerespunilla;uid=root;pwd=42218872Anto";


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
                        LinkFotos = com.LinkFotos,
                        LinkFacebook=com.LinkFacebook,
                        LinkInstagram=com.LinkInstagram,
                        Telefono=com.Telefono
                 
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
                result.LinkFacebook=complejo.LinkFacebook;
                result.LinkInstagram=complejo.LinkInstagram;
                result.Telefono=complejo.Telefono;
                
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
        

    [HttpGet]     
    [Route("api/Alojamiento/lista/{fechaIngreso}/{fechaEgreso}")]        
    public ActionResult<ResultadoAlojamiento> GetAlojamientosDisponibles(string fechaIngreso, string fechaEgreso)
        {
            string query = @"SELECT a.*
                            FROM alquilerespunilla.alojamientos a
                            WHERE a.idAlojamientos NOT IN (
                                SELECT e.IdAlojamiento
                                FROM alquilerespunilla.estadias e
                                WHERE (e.FechaIngreso <= @FechaIngreso AND e.FechaEgreso >= @FechaIngreso)
                                    OR (e.FechaIngreso <= @FechaEgreso AND e.FechaEgreso >= @FechaEgreso)
                                    OR (e.FechaIngreso >= @FechaIngreso AND e.FechaEgreso <= @FechaEgreso)
                            )";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                command.Parameters.AddWithValue("@FechaEgreso", fechaEgreso);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                ResultadoAlojamiento resultado = new ResultadoAlojamiento();
                resultado.listaAlojamiento = new List<ItemAlojamiento>();

                while (reader.Read())
                {
                    ItemAlojamiento item = new ItemAlojamiento();
                    item.IdAlojamiento = reader.IsDBNull(reader.GetOrdinal("idAlojamientos")) ? null : (int?)reader.GetInt32("idAlojamientos");
                    item.IdComplejo = reader.IsDBNull(reader.GetOrdinal("IdComplejo")) ? null : (int?)reader.GetInt32("IdComplejo");
                    item.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion");
                    item.CantidadPersonas = reader.GetInt32("CantidadPersonas");
                    item.LinkFotos = reader.IsDBNull(reader.GetOrdinal("LinkFotos")) ? null : reader.GetString("LinkFotos");

                    resultado.listaAlojamiento.Add(item);
                }

                return resultado;
            }
        }
    [HttpGet]     
    [Route("api/Alojamiento/lista/{fechaIngreso}/{fechaEgreso}/{idComplejo}")]        
    public ActionResult<ResultadoAlojamiento> GetDisponibles(string fechaIngreso, string fechaEgreso,int idComplejo)
        {
            string query = @"SELECT a.*
                            FROM alquilerespunilla.alojamientos a
                            WHERE a.idAlojamientos NOT IN (
                                SELECT e.IdAlojamiento
                                FROM alquilerespunilla.estadias e
                                WHERE(e.FechaIngreso <= @FechaIngreso AND e.FechaEgreso >= @FechaIngreso)
                                    OR (e.FechaIngreso <=@FechaEgreso AND e.FechaEgreso >= @FechaEgreso)
                                    OR (e.FechaIngreso >= @FechaIngreso AND e.FechaEgreso <= @FechaEgreso))
                                    and  a.IdComplejo = @idComplejo";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                command.Parameters.AddWithValue("@FechaEgreso", fechaEgreso);
                command.Parameters.AddWithValue("@idComplejo", idComplejo);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                ResultadoAlojamiento resultado = new ResultadoAlojamiento();
                resultado.listaAlojamiento = new List<ItemAlojamiento>();

                while (reader.Read())
                {
                    ItemAlojamiento item = new ItemAlojamiento();
                    item.IdAlojamiento = reader.IsDBNull(reader.GetOrdinal("idAlojamientos")) ? null : (int?)reader.GetInt32("idAlojamientos");
                    item.IdComplejo = reader.IsDBNull(reader.GetOrdinal("IdComplejo")) ? null : (int?)reader.GetInt32("IdComplejo");
                    item.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion");
                    item.CantidadPersonas = reader.GetInt32("CantidadPersonas");
                    item.LinkFotos = reader.IsDBNull(reader.GetOrdinal("LinkFotos")) ? null : reader.GetString("LinkFotos");

                    resultado.listaAlojamiento.Add(item);
                }

                return resultado;
            }
        }
    

}
