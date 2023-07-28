namespace AlquileresPunilla.Resultados.Reporte;

public class ResultadoProvincia
{
        public List<lst> lista {get; set;} = new List<lst>();
    

}

public class lst
{
    public string Provincia { get; set; }
    public double CantPersonas { get; set; }
}
