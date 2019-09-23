namespace ExchangeRate.Models
{
    /// <summary>
    /// Modelo que almacena el tipo de cambio que provee la API
    /// </summary>
    public class TipoCambioModel
    {
        public string Moneda { get; set; }
        public string Precio { get; set; }
    }
}
