using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Complejo
{
    public int IdComplejo { get; set; }

    public string NombreComplejo { get; set; } = null!;
    public string? LinkFotos { get; set; }
    public string? LinkFacebook { get; set; }
    public string? LinkInstagram { get; set; }
        public string? Telefono { get; set; }

    public virtual ICollection<Alojamiento> Alojamientos { get; } = new List<Alojamiento>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
