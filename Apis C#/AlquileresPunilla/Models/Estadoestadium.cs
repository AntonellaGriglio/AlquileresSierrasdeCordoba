using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Estadoestadium
{
    public int IdEstadoEstadia { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Estadia> Estadia { get; } = new List<Estadia>();
}
