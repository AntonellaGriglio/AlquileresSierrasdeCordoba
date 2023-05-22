using System;
using System.Collections.Generic;

namespace AlquileresPunilla.Models;

public partial class Pago
{
    public int IdPagos { get; set; }

    public int Importe { get; set; }

    public int IdTipoPago { get; set; }

    public int IdFormaPago { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<Detalleestadium> Detalleestadia { get; } = new List<Detalleestadium>();

    public virtual Formasdepago IdFormaPagoNavigation { get; set; } = null!;

    public virtual Tipospago IdTipoPagoNavigation { get; set; } = null!;
}
