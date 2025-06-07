using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Utility.Emails
{
    public interface IEmailSenderSarl
    {
        Task SendEmailAsync(string to, string subject, string htmlBody, string? textBody = null);
    }
}