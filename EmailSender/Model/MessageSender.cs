using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmailSender.Model
{
    public class EmailSender
    {
        SmtpClient smtpClient = new SmtpClient();

        public bool isBodyHtml { private get; set; }

        public bool EnableSsl
        {
            set
            {
                smtpClient.EnableSsl = value;
            }
        }

        public string Host
        {
            set
            {
                smtpClient.Host = value;
            }
        }

        public string Port
        {
            set
            {
                smtpClient.Port = Int32.Parse(value);
            }
        }

        public EmailSender()
        {
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        public void SendEmails(MailMessage mailMessage)
        {
            if (mailMessage != null)
            {

            }


         void SetCredentials(string login, string password)
        {
                if (login != null && password != null)
                    smtpClient.Credentials = new NetworkCredential(login, password);

        }

        }
    }
}
