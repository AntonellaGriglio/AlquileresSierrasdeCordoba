using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Detalleestadium
{
    public int IdDetalleEstadia { get; set; }

    public int IdEstadia { get; set; }

    public int IdPago { get; set; }

    public virtual Estadia IdEstadiaNavigation { get; set; } = null!;

    public virtual Pago IdPagoNavigation { get; set; } = null!;
}
