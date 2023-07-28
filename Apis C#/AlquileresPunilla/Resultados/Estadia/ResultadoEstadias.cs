namespace AlquileresPunilla.Resultados.Estadia;

public class ResultadoEstadias
{
    public List<est> listaEstadia {get; set;} = new List<est>();
    

}

public class est
{
    public int NroEstadia { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaEgreso { get; set; }
    public int IdEstado { get; set; }
    public string Estado { get; set; }
    public int CantPersona { get; set; }
    public int Desayuno { get; set; }
    public int ImporteTotal { get; set; }
    public int ImportePendiente { get; set; }
    public int IdPersona { get; set; }
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public String Descripcion { get; set; }
}
