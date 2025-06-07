using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Utility.Emails
{
    public class MailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}