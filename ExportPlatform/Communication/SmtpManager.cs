using ExportPlatform.Properties;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ExportPlatform.Communication
{
    public static class SmtpManager
    {
        private const string DefEmailRegularExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static void SendAsync(string email)
        {
            var message = new MailMessage("info@psek.pl", email);
            
            message.Subject = Resources.EmailSubject;
            message.IsBodyHtml = false;

            message.Body = Resources.EmailTemplate;

            var client = new SmtpClient();
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}