using MailKit.Net.Smtp;
using MimeKit;
using SSTDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public string UnlockAccountMessageContent(string login, string forgotPassLink)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hi {login}! <br>");
            sb.AppendLine($"Unfortunately your account is locked out, to reset your password, please <a href = {forgotPassLink}>click this link<a/>. <br>");
            sb.AppendLine("<br>");
            sb.AppendLine("<p>SoccerScoreTyper</p>");

            return sb.ToString();
        }

        public string ConfirmEmailMessageContent(string login, string confirmationLink)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hi {login}! <br>");
            sb.AppendLine("Welcome to SoccerScoreTyper! We're excited you're joining us. <br>");
            sb.AppendLine("Ready to get started? First, verify your email address: <br>");
            sb.AppendLine($"<a href={confirmationLink}>Click here</a><br>");
            sb.AppendLine("Link will be active for 3 days.<br>");
            sb.AppendLine("If you have not registered on SoccerScoreTyper, please ignore this message. <br>");
            sb.AppendLine("But feel free to join our community of typers with your friends! <br>");
            sb.AppendLine("<br>");
            sb.AppendLine("<p>SoccerScoreTyper</p>");

            return sb.ToString();
        }

        public string ResetPasswordMessageContent(string login, string resetUrl)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Password reset requested <br> user: {login} <br>");
            sb.AppendLine($"<a href={resetUrl}>Click here</a> to reset your password. <br>");
            sb.AppendLine("Link will be active for 30 minutes <br>");
            sb.AppendLine("If you didn't ask to change your password, please ignore this message. <br>");
            sb.AppendLine( "<br>");
            sb.AppendLine("<p>SoccerScoreTyper</p>");

            return sb.ToString();
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            SendAsync(emailMessage);
        }


        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h3 style='color:black;'>{0}</h3>", message.Content) };

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //TODO: log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //TODO: log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
