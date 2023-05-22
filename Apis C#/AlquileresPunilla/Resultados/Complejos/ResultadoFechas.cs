namespace AlquileresPunilla.Resultados.Complejos;

public class ResultadoFechas
{
    public List<fecha> listaFechas {get; set;} = new List<fecha>();
    

}

public class fecha
{
    public DateTime FechaIngreso { get; set; }
    public DateTime  FechaEgreso { get; set; }
    public string Descripcion { get; set; }
}