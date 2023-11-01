using Domain.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;

        public MailKitEmailSender(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailToSend = new MailMessage
            {
                From = new MailAddress(_mailSettings.Mail),
                Subject = subject,
                Body = htmlMessage,
            };
            emailToSend.To.Add(new MailAddress(email));


            try
            {
                using var smtpClient = new SmtpClient()
                {
                    Host = _mailSettings.Host,
                    Port = _mailSettings.Port,
                    Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password),
                    EnableSsl = true,
                };

                smtpClient.Send(emailToSend);
                smtpClient.Dispose();

                Console.WriteLine("Email sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
