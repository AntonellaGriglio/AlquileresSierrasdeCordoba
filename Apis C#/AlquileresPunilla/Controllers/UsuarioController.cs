using AlquileresPunilla.Comandos.Usuarios;
using AlquileresPunilla.Models;
using AlquileresPunilla.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlquileresPunilla.Controllers;

public class UsuarioController : ControllerBase
{
    private readonly AlquilerespunillaContext _context;
    public UsuarioController(AlquilerespunillaContext Context){
    _context = Context;
}

    [HttpPost]
    [Route("api/user/login")]
    public async Task<ActionResult<ResultadoUsuarios>> login([FromBody] CmdUsuario cmd)
    {
        try
        {
            var rdo = new ResultadoUsuarios();
            var usuario = await _context.Usuarios.Where(c => c.NombreUsuario.Equals(cmd.NombreUsuario) &&
             c.Contraseña.Equals(cmd.Contraseña)).FirstOrDefaultAsync();

            if (User != null)
            {
                rdo.nombreUsuario = usuario.NombreUsuario;
                rdo.StatusCode = 200;
                rdo.IdComplejo = usuario.IdComplejo;
                rdo.id = usuario.IdUsuarios;
                return Ok(rdo);
            }
            else
            {
                rdo.setError("Usuario no encontrado");
                rdo.StatusCode = 400;
                return Ok(rdo);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }


    [HttpGet]
    [Route("api/user/getById/{id}")]
    public async Task<ActionResult<ResultadoUsuarios>> getUbyId(int id)
    {
        try
        {
            var result = new ResultadoUsuarios();
            var usuario = await _context.Usuarios.Where(c => c.IdUsuarios.Equals(id)).FirstOrDefaultAsync();

            if (usuario != null)
            {
                result.id = usuario.IdUsuarios;
                result.nombreUsuario = usuario.NombreUsuario;
                result.IdComplejo= usuario.IdComplejo;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

}

    
