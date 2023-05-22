using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Alojamiento
{
    public int IdAlojamientos { get; set; }

    public int IdComplejo { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CantidadPersonas { get; set; }

    public virtual ICollection<Estadia> Estadia { get; } = new List<Estadia>();
    public virtual ICollection<ImagenesAlojamiento> ImagenesAlojamiento { get; } = new List<ImagenesAlojamiento>();

    public virtual Complejo IdComplejoNavigation { get; set; } = null!;
    public string LinkFotos { get; internal set; }
}
