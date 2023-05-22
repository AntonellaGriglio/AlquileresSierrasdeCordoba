namespace AlquileresPunilla.Resultados.Reporte;

public class ResultadoEstadiaManiana
{
        public List<estadiaManiana> listaEstadia {get; set;} = new List<estadiaManiana>();
    

}

public class estadiaManiana
{
    public int NroEstadia { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaEgreso { get; set; }
    public int IdEstado { get; set; }
    public int CantPersona { get; set; }
    public int Desayuno { get; set; }
    public int ImporteTotal { get; set; }
    public int IdPersona { get; set; }
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public String Descripcion { get; set; }
    public String Estado { get; set; }
}

