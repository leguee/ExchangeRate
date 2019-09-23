using ExchangeRate.Enums;
using ExchangeRate.Models;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// cotizacion de real
    /// </summary>
    public class QuoteReal : IQuote
    {
        /// <summary>
        /// obtiene la cotizacion del dolar del repositorio
        /// </summary>
        /// <returns></returns>
        public async Task<TipoCambioModel> GetCotizacion()
        {
            TipoCambioModel tipoCambio = new TipoCambioModel();

            // obtengo del repositorio la cotizacion actual de la moneda en real
            ApiCambioToday cambioToday = new ApiCambioToday();
            QuoteModel cotizacionActual = await cambioToday.GetCotizacionActual(CurrencyCodeEnum.BRL);

            bool statusOk = cotizacionActual.Status.Equals("OK");
            tipoCambio.Moneda = statusOk ? nameof(CurrencyNameEnum.real) : "sin cotizacion";
            tipoCambio.Precio = statusOk ? cotizacionActual.Result.Amount : "S/N";

            return tipoCambio;
        }
    }
}
