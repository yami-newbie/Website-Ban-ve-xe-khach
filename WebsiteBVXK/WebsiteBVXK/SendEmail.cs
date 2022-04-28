using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace WebsiteBVXK
{
    //944819640567-5hlhr36h74iaavbi2le04mmub8tie9b7.apps.googleusercontent.com
    public class SendEmail
    {
        public void Send(string to, string subject, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("nhaxe1545@gmail.com", "Nhaxe123456"),
                EnableSsl = true
            };
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("nhaxe1545@gmail.com");

            mailMessage.To.Add(to);

            mailMessage.Subject = subject;

            mailMessage.Body = body;

            client.Send(mailMessage);
        }
    }
}
