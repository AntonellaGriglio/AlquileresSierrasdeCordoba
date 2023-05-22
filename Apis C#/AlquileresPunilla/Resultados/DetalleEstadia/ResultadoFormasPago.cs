namespace AlquileresPunilla.Resultados.DetalleEstadia;

public class ResultadoFormasPago
{
    public List<FormaDePago> listaFormaPago {get; set;} = new List<FormaDePago>();
    

}

public class FormaDePago
{
    public int IdFormasDePagos { get; set; }

    public string? Descripcion { get; set; }

}

