using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmailServices : IEmailServices
    {

        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("crazycentury001@gmail.com"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = "Daily Notes";

            //string isi = String.Join(",",request.Body);
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<div style='width:350px; height:200px; border: 1px solid black; padding:10px 15px 10px 15px;'> " +
                "<h3 style='text-align:center;'>DailyNotes<h3>" +
                request.Body +
                "</div>"
            };

            //Kirim email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("crazycentury001@gmail.com", "okxqqdfelyteitkk");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

