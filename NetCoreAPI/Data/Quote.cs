using ExchangeRate.Models;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// Contexto de las cotizaciones
    /// </summary>
    public class Quote
    {
        private readonly IQuote _strategyQuote;

        /// <summary>
        /// en el constructor se inyecta la estrategia que lo configura
        /// </summary>
        public Quote(IQuote strategyQuote)
        {
            _strategyQuote = strategyQuote;
        }

        /// <summary>
        /// delega a
        /// </summary>
        /// <returns></returns>
        public async Task<TipoCambioModel> GetCotizacion()
        {
            return await _strategyQuote.GetCotizacion();
        }

    }
}
