using System;
using System.Collections.Generic;

namespace ApiBanco.Models.Entities;

public partial class Usuarios
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool? EsAdmin { get; set; }

    public bool? EsOperador { get; set; }

    public DateTime? FechaDeRegistro { get; set; }

    public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
}
