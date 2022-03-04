namespace Misc.Services.EmailService;

public interface IEmailService
{
    void SendEmail(Message message);
}