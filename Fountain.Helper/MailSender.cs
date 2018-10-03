using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.Helper
{
    public static class MailSender
    {
        public static bool Send(MailAddressCollection Kime, string mesaj)
        {
            var Kimden = new MailAddress("","");
            var mail = new MailMessage();

            mail.From = Kimden;

            for (int i = 0; i <= Kime.Count - 1; i++)
            {
                mail.To.Add(Kime.ElementAt(i));
            }

           
            mail.Subject = "";
            mail.SubjectEncoding = Encoding.GetEncoding(1254);
            mail.Body = ""; //sth import
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;


            try
            {
                SmtpClient MailSmtp = new SmtpClient();
              
                MailSmtp.Host = "";
              
                MailSmtp.Port = 25;
                MailSmtp.Send(mail);
                MailSmtp = null;
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Fountain.Core.Logger.Logger.Debug("Hata Oluştu");
                Fountain.Core.Logger.Logger.Error(ex.Message, ex);

                mail.Dispose();
                return false;
            }
        }
    }
}