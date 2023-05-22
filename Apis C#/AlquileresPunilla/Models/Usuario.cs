using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdComplejo { get; set; }

    public virtual Complejo IdComplejoNavigation { get; set; } = null!;
}
