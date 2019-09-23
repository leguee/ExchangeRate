using ExchangeRate.Models;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// Interface strategy para obtener la cotizacion a implementar en cada moneda
    /// </summary>
    public interface IQuote
    {
        Task<TipoCambioModel> GetCotizacion();
    }
}
