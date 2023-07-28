using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Estadia
{
    public int NroEstadia { get; set; }

    public int IdPersona { get; set; }

    public DateTime Fecha { get; set; }

    public int IdEstado { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaEgreso { get; set; }

    public int CantPersonas { get; set; }

    public sbyte Desayuno { get; set; }

    public int ImporteTotal { get; set; }

    public int IdAlojamiento { get; set; }
    public int ImportePendiente { get; set; }

    public virtual ICollection<Detalleestadium> Detalleestadia { get; } = new List<Detalleestadium>();

    public virtual Alojamiento IdAlojamientoNavigation { get; set; } = null!;

    public virtual Estadoestadium IdEstadoNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
