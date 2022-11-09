using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Email
    {
        public static void CreateMail(string destinator, string code)
        {
            NetworkCredential login;
            SmtpClient client;
            MailMessage msg;

            login = new NetworkCredential("consEco.team@gmail.com", "wtowzznfclupjgfl");
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("consEco.team@gmail.com", "ConsEco", Encoding.UTF8) };
            msg.To.Add(destinator);
            msg.Subject = "sujet";
            msg.Body = code;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            client.SendAsync(msg, "sending ...");
        }
    }
}
