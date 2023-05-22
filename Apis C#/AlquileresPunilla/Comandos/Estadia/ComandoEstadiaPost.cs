namespace AlquileresPunilla.Comandos.Estadia;

public class ComandoEstadiaPost
{
    public int IdPersona { get; set; }
    public int NroEstadia { get; set; }
    public DateTime Fecha { get; set; }
    public int IdEstado { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaEgreso { get; set; }
    public int CantPersona { get; set; }
    public sbyte Desayuno { get; set; }
    public int ImporteTotal { get; set; }
    public int IdAlojamiento { get; set; }



}
