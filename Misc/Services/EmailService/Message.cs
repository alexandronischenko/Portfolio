using MimeKit;

namespace Misc.Services.EmailService;

public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => new MailboxAddress(x, "alexandr.onischenko.2003@gmail.com")));
        Subject = subject;
        Content = content;
    }
}