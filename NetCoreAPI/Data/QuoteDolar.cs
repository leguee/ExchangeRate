using ExchangeRate.Enums;
using ExchangeRate.Models;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// cotizador de dolar 
    /// </summary>
    public class QuoteDolar : IQuote
    {
        /// <summary>
        /// obtiene la cotizacion del dolar del repositorio
        /// </summary>
        /// <returns></returns>
        public async Task<TipoCambioModel> GetCotizacion()
        {
            TipoCambioModel tipoCambio = new TipoCambioModel();

            // obtengo del repositorio la cotizacion actual de la moneda en dolares
            QuoteModel cotizacionActual = await new ApiCambioToday().GetCotizacionActual(CurrencyCodeEnum.USD);

            bool statusOk = cotizacionActual.Status.Equals("OK");
            tipoCambio.Moneda = statusOk ? nameof(CurrencyNameEnum.dolar): "sin cotizacion" ;
            tipoCambio.Precio = statusOk ? cotizacionActual.Result.Amount: "S/N" ;

            return tipoCambio;
        }
    }
}
