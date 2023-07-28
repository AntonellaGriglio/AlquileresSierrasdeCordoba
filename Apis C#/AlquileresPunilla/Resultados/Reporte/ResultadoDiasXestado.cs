namespace AlquileresPunilla.Resultados.Reporte;

public class ResultadoDiasXestado
{
    public List<item> lista {get; set;} = new List<item>();
    

}

public class item
{
    public int DiasOcupados { get; set; }
    public string Estado { get; set; }

}
