using System;
using System.Collections.Generic;

namespace ApiBanco.Models.Entities;

public partial class Cajas
{
    public int IdCaja { get; set; }

    public string NombreCaja { get; set; } = null!;

    public sbyte? Estado { get; set; }

    public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
}
