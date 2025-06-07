using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MVCWebApp.Utility.Emails
{
    public class EmailServiceMailKit : IEmailSender
    {
        private readonly MailSettings _settings;
        public EmailServiceMailKit(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;

            email.Body = new BodyBuilder
            {
                HtmlBody = htmlMessage,
                TextBody = htmlMessage ?? string.Empty
            }.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, _settings.UseSsl);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    
        public async Task SendEmailAsync(
            List<string> to, 
            string subject, 
            string htmlBody, 
            string? textBody = null, 
            List<string>? cc = null, 
            List<string>? bcc = null)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));

            foreach (var address in to)
                email.To.Add(MailboxAddress.Parse(address));

            if (cc != null)
            {
                foreach (var address in cc)
                    email.Cc.Add(MailboxAddress.Parse(address));
            }
            if (bcc != null)
            {
                foreach (var address in bcc)
                    email.Bcc.Add(MailboxAddress.Parse(address));
            }

            email.Subject = subject;

            email.Body = new BodyBuilder
            {
                HtmlBody = htmlBody,
                TextBody = textBody ?? string.Empty
            }.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, _settings.UseSsl);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
    
}