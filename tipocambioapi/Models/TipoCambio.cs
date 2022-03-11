
using System.ComponentModel.DataAnnotations;

namespace TipoCambioAPI.Models
{
    public class TipoCambio
    {
        [Key]
        public int idTipoCambio { get; set; } 
        public string? idMonedaOrigen { get;set; }
        public string? idMonedaDestino { get;set; }
        public decimal valorTipoCambio { get; set; }
    }
}
