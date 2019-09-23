using ExchangeRate.Enums;
using ExchangeRate.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRate.Data
{
    /// <summary>
    /// Conexion con la api Cambio today
    /// </summary>
    public class ApiCambioToday
    {
        private HttpClient httpClient;

        /// <summary>
        /// Obtiene el tipo de cambio devuelto de la api
        /// </summary>
        /// <returns></returns>
        public async Task<QuoteModel> GetCotizacionActual(CurrencyCodeEnum code)
        {
            try
            {
                this.httpClient = new HttpClient();
                QuoteModel cambioToday = new QuoteModel();

                // TODO: obtenerlo con IOptions desde appSettings
                CredentialConectionApi _conf = new CredentialConectionApi()
                {
                    Url = "http://api.cambio.today/v1/quotes/{0}/{1}/json?quantity=1&key={2}",
                    Target = "ARS",
                    Key = "2388|XNqKbbax_KuK93xR^4dQk8mKjc^Bf*VC"
                };
                
                string cambiosTodayURL = string.Format(_conf.Url, code.ToString("g"), _conf.Target, _conf.Key);

                var response = await this.httpClient.GetAsync(cambiosTodayURL);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    cambioToday = JsonConvert.DeserializeObject<QuoteModel>(result);
                    return cambioToday;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un problema al intentar obtener la cotización");
            }

            return null;
        }
    }
}
