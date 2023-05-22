using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class ImagenesAlojamiento
{
    public int idImagenes { get; set; }

    public int idAlojamiento { get; set; } 

    public string LinkFotos { get; set; } = null!;


    public virtual Alojamiento IdAlojamientoNavigation { get; set; } = null!;

}