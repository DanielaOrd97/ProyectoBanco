using System;
using System.Collections.Generic;

namespace ApiBanco.Models.Entities;

public partial class Turnos
{
    public int IdTurno { get; set; }

    public int? UsuarioId { get; set; }

    public int? CajaId { get; set; }

    public string EstadoTurno { get; set; } = null!;

    public virtual Cajas? Caja { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
