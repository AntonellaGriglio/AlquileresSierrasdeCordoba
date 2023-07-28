namespace AlquileresPunilla.Resultados.Reporte; 
public class ResultadoPorAlojamiento{
      public List<ite> lista {get; set;} = new List<ite>();
    

}

public class ite
{
    public string Alojamiento { get; set; }
    public decimal ImporteTotal  { get; set; }
}

