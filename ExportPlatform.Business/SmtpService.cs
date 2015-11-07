using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExportPlatform.Business
{
    public class SmtpService
    {
        private const string DefEmailRegularExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public void Inform(string to, string subject, string template, string fromAddress)
        {
            var message = new MailMessage(fromAddress, to);

            message.Subject = subject;
            message.IsBodyHtml = false;

            message.Body = template;

            var client = new SmtpClient();
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
