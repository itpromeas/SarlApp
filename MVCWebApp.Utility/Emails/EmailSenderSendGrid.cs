using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MVCWebApp.Utility.Emails
{
    public class EmailSenderSendGrid : IEmailSender
    {
        public string SendGridSecret { get; set; }
        private readonly MailSettings _settings;
        public EmailSenderSendGrid(IConfiguration _config, IOptions<MailSettings> settings) {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
            _settings = settings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
            /*var client = new SendGridClient(SendGridSecret);

            var from = new EmailAddress(_settings.SenderEmail, _settings.SenderName);
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            return client.SendEmailAsync(message);*/
        }
    }
}