using Microsoft.Extensions.Configuration;
using MailKit.Security;
using MimeKit;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Dto;


namespace ShopTARgv23.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _config;

        public EmailsServices(IConfiguration config) 
        { 
            _config = config;
        }

        public void SendEmail(EmailDto dto)
        {
            var message = new MimeMessage();
            var usersName = _config.GetSection("EmailUserName").Value;
            message.From.Add(MailboxAddress.Parse(usersName));
            message.To.Add(MailboxAddress.Parse(dto.To));
            message.Subject = dto.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body
            };
            /*
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };*/

            foreach (var file in dto.Attachment)
            {
                if (file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        stream.Position = 0;
                        builder.Attachments.Add(file.FileName, stream.ToArray());
                    }
                }
            }

            message.Body = builder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                client.Authenticate(usersName, _config.GetSection("EmailPassword").Value);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
