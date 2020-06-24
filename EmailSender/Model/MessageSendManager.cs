using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace EmailSender.Model
{
    static class MessageSendManager
    {
        public static Options OptionsOfMailSending = new Options();
        public static MailMessage mailMessage = new MailMessage();

        static SmtpClient smtpClient = new SmtpClient();
        
        public static void Send()
        {
            smtpClient.UseDefaultCredentials = OptionsOfMailSending.UseDefaultCredentials;          

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        }
    }
}
