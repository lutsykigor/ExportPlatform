using ExportPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExportPlatform.Business
{
    public class CustomerService
    {
        private SmtpService _smtpService;
        public CustomerService()
        {
            _smtpService = new SmtpService();
        }
        public async Task<bool> Add(string email, string ip,
            string userWelcomeSubject, string userWelcomeBody,
            string userWelcomeFrom, string adminEmail,
            string adminInfoSubject, string adminInfoBody)
        {
            using (var context = new DataContext())
            {
                context.Customers.Add(new Customer
                {
                    Email = email,
                    IP = ip,
                    Product = string.Empty,
                    Amount = string.Empty,
                    Created = DateTime.Now
                });

                await context.SaveChangesAsync();

                try
                {

                    _smtpService.Inform(adminEmail, adminInfoSubject,
                        adminInfoBody, userWelcomeFrom);

                    var emails = ExtractEmails(email);
                    foreach (var parsedEmail in emails)
                    {
                        _smtpService.Inform(parsedEmail, userWelcomeSubject,
                            userWelcomeBody, userWelcomeFrom);
                    }
                }
                catch (Exception ex)
                {
                    context.Logs.Add(new Log
                    {
                        Email = email,
                        Message = ex.StackTrace,
                        Title = ex.Message,
                        Created = DateTime.Now
                    });
                    await context.SaveChangesAsync();
                    return false;
                }
            }

            return true;
        }

        private List<string> ExtractEmails(string content)
        {
            var data = new List<string>();

            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                RegexOptions.IgnoreCase);

            MatchCollection emailMatches = emailRegex.Matches(content);

            StringBuilder sb = new StringBuilder();

            foreach (Match emailMatch in emailMatches)
            {
                data.Add(emailMatch.Value);
            }
            return data;
        }
    }
}
