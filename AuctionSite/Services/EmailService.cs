﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class EmailService
    {

        public void SendMessage(string recipient, string mail)
        {
            MailAddress from = new MailAddress("6367394@mail.ru", "Auction");
            MailAddress to = new MailAddress(recipient);
            MailMessage startMessage = new MailMessage(from, to);

            startMessage.Subject = "Тест";
            startMessage.Body = $"{mail}";
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("6367394@mail.ru", "11213411qq");
            smtp.EnableSsl = true;
            smtp.Send(startMessage);
        }
    }
}
