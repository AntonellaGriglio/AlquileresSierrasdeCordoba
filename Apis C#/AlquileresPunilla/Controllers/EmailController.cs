using AlquileresPunilla.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AlquileresPunilla.Controllers
{
    [ApiController]

    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Api/Email")]
        public async Task<IActionResult> EnviarCorreo([FromBody] EmailModel correoModel)
        {
            var sendGridApiKey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(sendGridApiKey);
            var from = new EmailAddress("alquileressierrasdecordoba@gmail.com", "Alquileres Sierras de Cordoba");
            var to = new EmailAddress(correoModel.Destinatario,"hhh");
            var subject = correoModel.Asunto;
            var htmlContent = correoModel.Contenido;
            var plainTextContent = correoModel.Contenido;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return Ok("Correo electrónico enviado correctamente");
            }
            else
            {
                return BadRequest("No se pudo enviar el correo electrónico.");
            }
        }
    }
}
