using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Formasdepago
{
    public int IdFormasDePagos { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Pago> Pagos { get; } = new List<Pago>();
}
