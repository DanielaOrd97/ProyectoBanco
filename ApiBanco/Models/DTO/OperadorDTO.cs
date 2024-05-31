namespace ApiBanco.Models.DTO
{
    public class OperadorDTO
    {
        public int? Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool? EsOperador { get; set; }
        public DateTime? FechaDeRegistro { get; set; }
        public int? IdCaja { get; set; }
    }
}
