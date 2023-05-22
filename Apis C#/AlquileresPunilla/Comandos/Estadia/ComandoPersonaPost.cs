namespace AlquileresPunilla.Comandos.Estadia;

public class ComandoPersonaPost
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string IdLocalidad { get; set; }
    public string Descripcion { get; set; } = null!;
    public int IdProvincia { get; set; }
    public string Descripcion2 { get; set; } = null!;
    public int idComplejo { get; set; }
}
