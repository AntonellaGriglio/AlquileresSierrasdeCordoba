namespace AlquileresPunilla.Resultados.Complejos;

public class ResultadoAlojamiento
{
    public List<ItemAlojamiento> listaAlojamiento {get; set;} = new List<ItemAlojamiento>();
    

}

public class ItemAlojamiento
{
    public int? IdAlojamiento { get; set; }
    public int? IdComplejo { get; set; }
    public string? Descripcion { get; set; }
    public int CantidadPersonas { get; set; }
    public string LinkFotos { get; set; }
}