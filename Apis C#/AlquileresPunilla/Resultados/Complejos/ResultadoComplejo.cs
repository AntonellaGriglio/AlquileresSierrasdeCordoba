namespace AlquileresPunilla.Resultados.Complejos;

public class ResultadoComplejo
{
    public List<ItemComplejo> listaComplejos {get; set;} = new List<ItemComplejo>();
    

}

public class ItemComplejo
{
    public int IdComplejo { get; set; }
    public string NombreComplejo { get; set; }
    public string? LinkFotos { get; set; }
}