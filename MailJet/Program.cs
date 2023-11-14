using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mailjet
{
    class Program
    {
        /// <summary>
        /// This call sends an email to one recipient.
        /// </summary>
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            Console.WriteLine("Hello gmail");
            string messageTo = "tekato1998@gmail.com";
            string messageFrom = "tekato2002@gmail.com";
            string appPassword = "ubnnnxoejohndbgm";

            var email = new MailMessage
            {
                From = new MailAddress(messageFrom),
                Subject = "Reset password email",
                Body = "Test email"
            };
            email.To.Add(new MailAddress(messageTo));

            try
            {
                using var smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(messageFrom, appPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(email);
                smtpClient.Dispose();
                Console.WriteLine("Email sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            //{
            //    smtpClient.Port = 587;
            //    smtpClient.Credentials = new NetworkCredential(messageFrom, appPassword);
            //    smtpClient.EnableSsl = true;

            //    MailMessage mailMessage = new MailMessage
            //    {
            //        From = new MailAddress(messageFrom),
            //        Subject = "Test Email",
            //        Body = "This is a test email body."
            //    };
            //    mailMessage.To.Add(messageTo);

            //    smtpClient.Send(mailMessage);
            //}
        }
    }
}