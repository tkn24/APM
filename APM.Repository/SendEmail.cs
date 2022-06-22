using APM.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace APM.Repository
{
    public class SendEmail : ISendEmail
    {
        public void Send(string Subject, string Email, string Body)
        {
            // kimlik bilgileri
            var credentials = new NetworkCredential("*****@gmail.com", "password");

            var mail = new MailMessage()
            {
                From = new MailAddress("*****@gmail.com"),
                Subject = Subject,
                Body = Body
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(Email));

            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials,
            };
            client.Send(mail);
        }
    }
}
