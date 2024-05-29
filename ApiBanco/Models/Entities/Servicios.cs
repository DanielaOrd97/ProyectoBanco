using System;
using System.Collections.Generic;

namespace ApiBanco.Models.Entities;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
}
