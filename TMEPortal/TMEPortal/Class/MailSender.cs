using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Class
{
    public class MailSender
    {
        public void SendMessage(string To, string Message, string Subject, bool Html)
        {
            try
            {
                System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                            new System.Net.Mail.MailAddress("TMENotReply@hotmail.com", "TME Web Registration"),
                            new System.Net.Mail.MailAddress(To));
                m.Subject = Subject;
                m.Body = Message;
                m.IsBodyHtml = Html;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.live.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("TMENotReply@hotmail.com", "Elemento1!");


                smtp.Send(m);
            }
            catch (Exception)
            {

                throw;
            }






        }
    }
}