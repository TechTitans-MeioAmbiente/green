using EmailService.DTOs;

namespace EmailService.Services
{
    public interface IMessageService
    {
        void SendEmail(EmailDTO request);
    
    }
}
