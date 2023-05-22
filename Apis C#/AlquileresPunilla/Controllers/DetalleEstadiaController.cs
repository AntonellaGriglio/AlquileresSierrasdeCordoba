using AlquileresPunilla.Comandos.Estadia;
using AlquileresPunilla.Models;
using AlquileresPunilla.Resultados.DetalleEstadia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlquileresPunilla.Controllers;

public class DetalleEstadiaController : ControllerBase
{
     private readonly AlquilerespunillaContext Context;

    public  DetalleEstadiaController(AlquilerespunillaContext context){
        Context = context;
    }


    [HttpGet]
    [Route("api/DetalleEstadia/listaFormasdePago")]
    public async Task<ActionResult<ResultadoFormasPago>> listaFormasdePago()
    {
        try
        {
            var result = new ResultadoFormasPago();
            var formasdepago = await Context.Formasdepagos.ToListAsync();
            if (formasdepago != null)
            {
                foreach (var form in formasdepago)
                {
                    var resultAux = new FormaDePago(){
                        IdFormasDePagos=form.IdFormasDePagos,
                        Descripcion=form.Descripcion,
                    };
                    result.listaFormaPago.Add(resultAux);
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
    [HttpGet]
    [Route("api/DetalleEstadia/listaTipoPagos")]
    public async Task<ActionResult<ResultadoTiposPago>> listaTiposPagos()
    {
        try
        {
            var result = new ResultadoTiposPago();
            var tipospagos = await Context.Tipospagos.ToListAsync();
            if (tipospagos != null)
            {
                foreach (var com in tipospagos)
                {
                    var resultAux = new TipoPago(){
                        IdTiposPagos=com.IdTiposPagos,
                        Descripcion = com.Descripcion,

                    };
                    result.listaTiposPago.Add(resultAux);
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
  [Route("Api/DetalleEstadia/Registrar/DetalleEstadia")]

  public async Task<ActionResult<ResultadoDetalleEstadiaPost>> RegistrarDetalleEstadia([FromBody] DetalleEstadiaPost comando) {
    try
    {

      var detalleEstadia = new Detalleestadium
      {
        IdDetalleEstadia= comando.IdDetalleEstadia,
        IdEstadia = comando.IdEstadia,
        IdPago = comando.IdPago,

      };


      
      Context.Detalleestadia.Add(detalleEstadia);
      await Context.SaveChangesAsync();
      var result = new ResultadoDetalleEstadiaPost{
        Id = detalleEstadia.IdDetalleEstadia,
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
  [Route("Api/DetalleEstadia/Registrar/Pago")]

  public async Task<ActionResult<ResultadoPagoPost>> RegistrarPago([FromBody] ComandoPagoPost comando) {
    try
    {

      var pago = new Pago
      {
        IdPagos= comando.IdPago,
        Importe=comando.Importe,
        IdTipoPago=comando.IdTipoPago,
        IdFormaPago=comando.IdFormaPago,
        Fecha = DateTime.Now
        
      };


      
      Context.Pagos.Add(pago);
      await Context.SaveChangesAsync();
      var result = new ResultadoPagoPost{
        IdPago = pago.IdPagos,
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
    [Route("api/DetalleEstadia/Pago/{id}")]
    public async Task<ActionResult<ResultadoListaPagos>> ListaPagos(int id)
    {
        try
        {
            var result = new ResultadoListaPagos();
            var pagos = await (from dt in Context.Detalleestadia
                           join e in Context.Estadias on dt.IdEstadia equals e.NroEstadia
                           join al in Context.Alojamientos on e.IdAlojamiento equals al.IdAlojamientos
                           join com in Context.Complejos on al.IdComplejo equals com.IdComplejo
                           join pe in Context.Personas on e.IdPersona equals pe.Idpersona
                           join p in Context.Pagos on dt.IdPago equals p.IdPagos
                           join tp in Context.Tipospagos  on p.IdTipoPago equals tp.IdTiposPagos
                           join fp in Context.Formasdepagos on p.IdFormaPago equals fp.IdFormasDePagos
                           where com.IdComplejo == id
                           select new
                           {
                               Fecha = e.Fecha,
                               FechaIngreso = e.FechaIngreso,
                               FechaEgreso = e.FechaEgreso,
                               ImporteTotal = e.ImporteTotal,
                               IdPersona = pe.Idpersona,
                               Nombre = pe.Nombre,
                               Apellido = pe.Apellido,
                               Importe = p.Importe,
                               IdPago = p.IdPagos,
                               FechaPago = p.Fecha,
                               TipoPago = tp.Descripcion,
                               FormaPago = fp.Descripcion
                           }).ToListAsync();
;
            if(pagos != null)
            {
                foreach (var pag in pagos)
                {
                    var pago= new pago(){
                      FechaEstadia=pag.Fecha,
                      FechaIngreso=pag.FechaIngreso,
                      FechaEgreso=pag.FechaEgreso,
                      ImporteTotal=pag.ImporteTotal,
                      IdPersona= pag.IdPersona,
                      Nombre=pag.Nombre,
                      Apellido=pag.Apellido,
                      IdPago=pag.IdPago,
                      ImportePago=pag.Importe,
                      FechaPago=pag.FechaPago,
                      TipoPago=pag.TipoPago,
                      FormaPago=pag.FormaPago

                    };
                    result.listaPagos.Add(pago);
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
  [Route("Api/DetalleEstadia/Modifiacar/Pago")]

  public async Task<ActionResult<ResultadoPagoPost>> ModificarPago([FromBody] ComandoPagoPost comando) {
    try
    {

      var pago = new Pago
      {
        IdPagos= comando.IdPago,
        Importe=comando.Importe,
        IdTipoPago=comando.IdTipoPago,
        IdFormaPago=comando.IdFormaPago,
        Fecha = DateTime.Now
        
      };


      
      Context.Pagos.Update(pago);
      await Context.SaveChangesAsync();
      var result = new ResultadoPagoPost{
        IdPago = pago.IdPagos,
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
  [Route("Api/DetalleEstadia/GetPagoXId/{Id}")]
  
    public async Task<ActionResult<ResultadoPago>> GetPagoXId(int Id)
    {
        try
        {
            var result = new ResultadoPago();
            var pago = await Context.Pagos.Where(p => p.IdPagos == Id).FirstOrDefaultAsync();
            if (pago != null)
            {
              result.Fecha=pago.Fecha;
              result.IdFormaPago=pago.IdFormaPago;
              result.IdTipoPago=pago.IdTipoPago;
              result.IdPago=Id;
              result.Importe=pago.Importe;

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

}
