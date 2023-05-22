using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Localidade
{
    public string IdLocalidades { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdProvicia { get; set; }

    public virtual Provincia IdProviciaNavigation { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
