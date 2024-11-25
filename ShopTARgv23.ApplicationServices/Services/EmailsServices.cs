using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using MailKit.Net.Smtp;
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

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };
            
            using (var client = new SmtpClient())
            {
                client.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                client.Authenticate(usersName, _config.GetSection("EmailPassword").Value);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
