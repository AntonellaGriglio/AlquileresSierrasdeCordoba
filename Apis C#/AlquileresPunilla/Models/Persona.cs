using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Persona
{
    public int Idpersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } 

    public string Email { get; set; }

    public sbyte Estado { get; set; }

    public string IdLocalidad { get; set; }
    public int idComplejo { get; set; }

    public virtual ICollection<Estadia> Estadia { get; } = new List<Estadia>();

    public virtual Localidade IdLocalidadNavigation { get; set; } = null!;
}
