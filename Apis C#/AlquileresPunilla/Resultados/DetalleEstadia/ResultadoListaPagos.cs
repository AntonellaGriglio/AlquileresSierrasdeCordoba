using System;
namespace AlquileresPunilla.Resultados.DetalleEstadia;

public class ResultadoListaPagos
{
     public List<pago> listaPagos {get; set;} = new List<pago>();
    

}

public class pago
{
    public DateTime FechaEstadia { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaEgreso { get; set; }
    public int ImporteTotal { get; set; }
    public int IdPersona { get; set; }
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public int ImportePago { get; set; }
    public int IdPago { get; set; }
    public DateTime FechaPago { get; set; }
    public String TipoPago { get; set; }
    public String FormaPago { get; set; }
}
