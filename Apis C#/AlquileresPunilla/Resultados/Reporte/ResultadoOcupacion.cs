namespace AlquileresPunilla.Resultados.Reporte;

public class ResultadoOcupacion
{
    public List<Item> lista {get; set;} = new List<Item>();

}

public class Item
{
    public int TotalDiasOcupados { get; set; }
    public string Descripcion { get; set; }
}
