using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlquileresPunilla.Controllers
{
    [ApiController]
    [Route("api/mercadopago")]
    public class MercadoPagoController : ControllerBase
    {
        private readonly string accessToken = "APP_USR-4840194807764590-052219-f9b67fa665ba1df51958449157601636-187629741";

        [HttpGet("obtener-enlace")]
        public async Task<IActionResult> ObtenerEnlacePago(float importe)
        {


            // Crea el objeto JSON con los datos de la preferencia de pago
            var preferenceData = new
            {
                items = new[]
                {
                    new
                    {
                        title = "Alquileres",

                        quantity = 1,
                        currency_id = "ARG",
                        unit_price = importe
                    }
                }
            };

            // Convierte el objeto JSON a una cadena
            string jsonData = JsonConvert.SerializeObject(preferenceData);

            // Crea un objeto StringContent con los datos JSON
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Crea una instancia de HttpClient
            using (var httpClient = new HttpClient())
            {
                // Establece el token de acceso en el encabezado de autorización
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Envía la solicitud POST para crear la preferencia
                var response = await httpClient.PostAsync("https://api.mercadopago.com/checkout/preferences", content);

                // Verifica si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Lee la respuesta JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Extrae el enlace de pago de la respuesta JSON
                    string enlacePago = ExtractPaymentLink(jsonResponse);

                    return Ok(new { enlacePago });
                }
                else
                {
                    // La solicitud no fue exitosa, devuelve un mensaje de error
                    return BadRequest($"Error al crear la preferencia de pago {response}");
                }
            }
        }

        private string ExtractPaymentLink(string jsonResponse)
        {
            dynamic responseObj = JsonConvert.DeserializeObject(jsonResponse);
            string enlacePago = responseObj?.init_point ?? string.Empty;

            return enlacePago;
        }
    }
}
