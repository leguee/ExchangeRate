using ExchangeRate.Data;
using ExchangeRate.Enums;
using ExchangeRate.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [DisableCors]
    public class CotizacionController : ControllerBase
    {
        // GET: api/Cotizacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCambioModel>>> Get()
        {
            return new List<TipoCambioModel>
            {
                await new Quote(new QuoteDolar()).GetCotizacion(),
                await new Quote(new QuoteEuro()).GetCotizacion(),
                await new Quote(new QuoteReal()).GetCotizacion()
            };
        }

        // GET: api/Cotizacion/{moneda}
        [HttpGet("{moneda}", Name = "Get")]
        public async Task<ActionResult<TipoCambioModel>> Get(string moneda)
        {
            TipoCambioModel tipoCambio = new TipoCambioModel()
            {
                Moneda = "No definido",
                Precio = "N/A"
            };
            
            switch (moneda.ToLower())
            {
                case  nameof(CurrencyNameEnum.dolar):
                    tipoCambio = await new Quote(new QuoteDolar()).GetCotizacion();
                    break;
                case nameof(CurrencyNameEnum.euro):
                    tipoCambio = await new Quote(new QuoteEuro()).GetCotizacion();
                    break;
                case nameof(CurrencyNameEnum.real):
                    tipoCambio = await new Quote(new QuoteReal()).GetCotizacion();
                    break;
                default:
                    break;
            }

            return Ok(tipoCambio);
        }
    }
}
