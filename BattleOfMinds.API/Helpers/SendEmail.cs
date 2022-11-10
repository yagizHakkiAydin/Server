using BattleOfMinds.Models.Models;
using System.Net.Mail;

namespace BattleOfMinds.API.Helpers
{
    public class SendEmail
    {

        public async Task<bool> UserSendEmail(Users user)
        {

            string body = "Dear " + "@" + user.UserName + ",\r\n \r\n";
            body += "Welcome to Battle Of Minds!\r\n \r\n";
            body += "Your SignUp Code is : " + user.ApprovedCode + "\r\n \r\n";

            try
            {
                MailMessage eMail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                eMail.From = new MailAddress("battleofmindsgame@gmail.com");
                eMail.To.Add(user.Email);
                eMail.Subject = "Battle Of Minds Activation";
                eMail.Body = body;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("battleofmindsgame@gmail.com", "nvephvzffetchfge");
                await smtp.SendMailAsync(eMail);
                eMail.Dispose();
                smtp.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> ForgetPasswordEmail(Users user)
        {

            string body = "Dear " + "@" + user.UserName + ",\r\n \r\n";
            body += "Your new password : " + user.Password + "\r\n \r\n";
            try
            {
                MailMessage eMail = new MailMessage();
                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                eMail.From = new MailAddress("battleofmindsgame@gmail.com");
                eMail.To.Add(user.Email);
                eMail.Subject = "Battle Of Minds Forget Password";
                eMail.Body = body;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("battleofmindsgame@gmail.com", "nvephvzffetchfge");
                await smtp.SendMailAsync(eMail);
                eMail.Dispose();
                smtp.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
