using ExchangeRate.Enums;
using ExchangeRate.Models;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// cotizadocion de Euro
    /// </summary>
    public class QuoteEuro : IQuote
    {
        /// <summary>
        /// obtiene la cotizacion del dolar del repositorio
        /// </summary>
        /// <returns></returns>
        public async Task<TipoCambioModel> GetCotizacion()
        {
            TipoCambioModel tipoCambio = new TipoCambioModel();

            // obtengo del repositorio la cotizacion actual de la moneda en euro
            ApiCambioToday cambioToday = new ApiCambioToday();
            QuoteModel cotizacionActual = await cambioToday.GetCotizacionActual(CurrencyCodeEnum.EUR);

            bool statusOk = cotizacionActual.Status.Equals("OK");
            tipoCambio.Moneda = statusOk ? nameof(CurrencyNameEnum.euro) : "sin cotizacion";
            tipoCambio.Precio = statusOk ? cotizacionActual.Result.Amount : "S/N";

            return tipoCambio;
        }
    }
}
