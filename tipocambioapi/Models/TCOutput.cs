namespace TipoCambioAPI.Models
{
    public class TCOutput
    {
        public decimal monto { get; set; }
        public decimal montoTipoCambio { get; set; }
        public string? monedaOrigen { get; set; }
        public string? monedaDestino { get; set; }
        public decimal tipoCambio { get; set;}
    }
}
