using SSTDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        string ResetPasswordMessageContent(string login, string resetUrl);
        string ConfirmEmailMessageContent(string login, string confirmationLink);
        string UnlockAccountMessageContent(string login, string forgotPassLink);
    }
}
