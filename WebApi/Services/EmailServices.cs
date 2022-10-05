using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Utilities;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmailServices : IEmailServices
    {

        public void SendEmail(EmailDTO notes)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse());
            email.To.Add(MailboxAddress.Parse(notes.To));
            email.Subject = "Daily Notes";

            //string isi = String.Join(",",request.Body);
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = notes.EmailBody() };

            //Kirim email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate();
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

