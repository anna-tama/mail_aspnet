using System.Net;
using System.Net.Mail;

namespace PTC
{
    public class SendMail
    {
        public static void Email(string to, string subject, string body)
        {
            MailMessage mm = new();
            mm.To.Add(new MailAddress(to));
            mm.From = new MailAddress("anna.tama.roma@gmail.com");
            mm.Subject = subject;   
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            SmtpClient smtp = new ();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;    
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("anna.tama.roma@gmail.com", "npmsaikjjdfputqa");
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Send(mm);

        }

    }
}
 