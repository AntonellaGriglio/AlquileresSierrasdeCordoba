namespace AlquileresPunilla.Resultados.Clientes;

public class ResultadoListaClientes
{
      public List<cliente> listaClientes {get; set;} = new List<cliente>();
    

}

public class cliente
{
     public int Idpersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

}

