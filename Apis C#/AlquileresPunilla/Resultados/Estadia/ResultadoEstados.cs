namespace AlquileresPunilla.Resultados.Estadia;

public class ResultadoEstados
{
    public List<ItemEstado> listaEstado {get; set;} = new List<ItemEstado>();
    

}

public class ItemEstado
{
    public int IdEstado { get; set; }
    public string Descripcion { get; set; }
}

