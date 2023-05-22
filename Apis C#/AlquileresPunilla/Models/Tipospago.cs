using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Tipospago
{
    public int IdTiposPagos { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; } = new List<Pago>();
}
