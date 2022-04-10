using System.Net;
using System.Net.Mail;
using YatchMasterWS.Models.Request;

namespace YatchMasterWS.Utils.Helper
{
    public class MailHelper
    {
        public static async Task<dynamic> SendEmailAsync(MailRequest mailRequest)
        {
            var mailSettings = ConfigHelper.GetSection("MailSettings");

            if (mailSettings != null)
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(mailSettings["Email"]),
                    Subject = mailRequest.Subject,
                    Body = mailRequest.Body
                };
                mail.To.Add(mailRequest.To_email ?? "");

                var smtp = new SmtpClient(mailSettings["Server"])
                {
                    Port = int.Parse(mailSettings["Port"]),
                    Credentials = new NetworkCredential(mailSettings["Username"], mailSettings["Password"]),
                    EnableSsl = true,

                };
                await smtp.SendMailAsync(mail);
                smtp.Dispose();
                return true;

            }
            else return false;
        }
    }
}
