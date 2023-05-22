namespace AlquileresPunilla.Resultados.Complejos;

public class ResultadoImgAloj

{
     public List<Imagenes> listaImagenes {get; set;} = new List<Imagenes>();
    

}

public class Imagenes
{
    public int? idImagenes { get; set; }
    public int? idAlojamiento { get; set; }
    public string LinkFotos { get; set; }
}
