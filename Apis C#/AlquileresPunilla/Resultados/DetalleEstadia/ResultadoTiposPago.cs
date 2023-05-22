namespace AlquileresPunilla.Resultados.DetalleEstadia;

public class ResultadoTiposPago
{
    public List<TipoPago> listaTiposPago {get; set;} = new List<TipoPago>();
    

}

public class TipoPago
{
 public int IdTiposPagos { get; set; }

    public string Descripcion { get; set; } = null!;

}

