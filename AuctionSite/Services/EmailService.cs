using AuctionSite.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class EmailService: IEmailService
    {

        public void SendMessage(string recipient, string mail)
        {
            var from = new MailAddress("6367394@mail.ru", "Auction");
            var to = new MailAddress(recipient);
            var startMessage = new MailMessage(from, to);

            startMessage.Subject = "Тест";
            startMessage.Body = $"{mail}";

            var smtp = new SmtpClient("smtp.mail.ru", 587);

            smtp.Credentials = new NetworkCredential("6367394@mail.ru", "11213411qq");
            smtp.EnableSsl = true;
            smtp.Send(startMessage);
        }
        public void ConfirmEmail(string recipient, Guid code, string callbackUrl,string header, string text)
        {
            var from = new MailAddress("6367394@mail.ru", "Admin");
            var to = new MailAddress(recipient);
            var startMessage = new MailMessage(from, to);

            startMessage.Subject = header;
            startMessage.Body = text;

            var smtp = new SmtpClient("smtp.mail.ru", 587);

            smtp.Credentials = new NetworkCredential("6367394@mail.ru", "11213411qq");
            smtp.EnableSsl = true;
            smtp.Send(startMessage);
        }
    }
}
