using EmailService.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;


namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMessageService _MessageService;

        public EmailController(IMessageService messageService)
        {
            _MessageService = messageService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            _MessageService.SendEmail(request);
            return Ok("Email enviado com sucesso!");
        }
    }
}
