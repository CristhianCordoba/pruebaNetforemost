using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    public class ModeGestoresSaldos
    {
        [Key]
        public int id_gestor { get; set; }
        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? correo_electronico { get; set; }
        public decimal? saldo_gestor { get; set; }
    }
}