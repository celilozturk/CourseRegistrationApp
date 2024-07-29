using MimeKit;
namespace Domain.Entities;
public class EmailMessage
{
    public string Subject { get; set; }
    public string TextBody { get; set; }
    public string HtmlBody { get; set; }
    public AttachmentCollection? Attachments { get; set; }
    public string ToFullName { get; set; }
    public string ToEmail { get; set; }

}
