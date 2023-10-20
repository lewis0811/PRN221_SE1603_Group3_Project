using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
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
            MailjetClient client = new MailjetClient("bc27b16a65d9bfb55278b9a3625a1b24", "bfeda7b61ef16640c21f654f85a3f259");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "ezlewis01@protonmail.com")
               .Property(Send.FromName, "Mailjet Pilot")
               .Property(Send.Subject, "Your email flight plan!")
               .Property(Send.TextPart, "Dear passenger, welcome to Mailjet! May the delivery force be with you!")
               .Property(Send.HtmlPart, "<h3>Dear passenger, welcome to <a href=\"https://www.mailjet.com/\">Mailjet</a>!<br />May the delivery force be with you!")
               .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", "tekato1998@gmail.com"}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
    }
}