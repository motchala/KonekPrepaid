using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace KonekLogicProcess
{
    class EmailService
    {
        public void SendEmail(string accountNumber)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Successful Transaction", "do-not-reply@atm.com"));
            message.To.Add(new MailboxAddress("Account Owner", "user@example.com"));
            message.Subject = "Account Transaction";
            message.Body = new TextPart("plain")
            {
                Text = $"Account {accountNumber}\n\n" +
                        "A transaction was made to your account.\n\n"
            };

            using (var client = new SmtpClient())
            {
                var smtpHost = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHost, smtpPort, tls);

                var userName = "5db290b7234a85";
                var password = "13e7b2d9ad37a3";

                client.Authenticate(userName, password);

                client.Send(message);
                client.Disconnect(true);

            }




        }
    }
}