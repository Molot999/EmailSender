using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace EmailSender.Model
{
    static class MessageSendManager
    {
        public static Options OptionsOfMailSending = new Options();

        public static ObservableCollection<string> AttachmentsOfMail = new ObservableCollection<string>();

        public static ObservableCollection<MailAddress> RecepientsOfMail = new ObservableCollection<MailAddress>();

        public static MailMessage SendingMail = new MailMessage();

        static SmtpClient smtpClient = new SmtpClient();
        
        private static void SetSendingOptions()
        {
            smtpClient.UseDefaultCredentials = OptionsOfMailSending.GetUseDefaultCredentials();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Host = OptionsOfMailSending.SmtpHost;
            smtpClient.Port = OptionsOfMailSending.SmtpPort;
            smtpClient.EnableSsl = OptionsOfMailSending.UseSSL;
            smtpClient.Credentials = new NetworkCredential(OptionsOfMailSending.Login, OptionsOfMailSending.Password);

        }

        private static void FormMail()
        {
            foreach (string mailAttachment in AttachmentsOfMail)
                SendingMail.Attachments.Add(new Attachment(mailAttachment));

            foreach (MailAddress mailRecepient in RecepientsOfMail)
                SendingMail.To.Add(mailRecepient);
        }

        public static void Send()
        {
            SetSendingOptions();
            FormMail();

            smtpClient.Send(SendingMail);
        }
    }
}
