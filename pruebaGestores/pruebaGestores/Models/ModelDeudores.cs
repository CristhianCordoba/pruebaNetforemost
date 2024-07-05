using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    public class DeudoresModel
    {
        [Key]
        public int id_cliente { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public int? factura { get; set; }
        public decimal? saldo { get; set; }
        public string? estado_deuda { get; set; }
        public string? fecha_ultimo_pago { get; set; }
        public string? comentarios { get; set; }
    }
}