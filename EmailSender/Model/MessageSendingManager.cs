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
    static class MessageSendingManager
    {
        
        private static SmtpOptions sendingOptions = new SmtpOptions();

        private static ObservableCollection<string> mailAttachments = new ObservableCollection<string>();

        private static ObservableCollection<MailAddress> mailRecipients = new ObservableCollection<MailAddress>();

        private static MailMessage sendingMail;

        private static SmtpClient smtpClient = new SmtpClient();

        public static void SetSendingOptions(SmtpOptions optionsOfSending) => sendingOptions = optionsOfSending;

        public static void SetMailAttachments(ObservableCollection<string> mailAttachments) => MessageSendingManager.mailAttachments = mailAttachments;

        public static ObservableCollection<string> GetMailRecipients() => mailAttachments;

        public static void SetMailMessage(MailMessage sendingMail) => MessageSendingManager.sendingMail = sendingMail;

        private static void SetSendingOptions()
        {
            bool useDefaultCredentials = sendingOptions.GetUseDefaultCredentials();

            if (useDefaultCredentials == true)
                smtpClient.UseDefaultCredentials = true;
            else
                smtpClient.UseDefaultCredentials = false;

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Host = sendingOptions.SmtpHost;
            smtpClient.Port = sendingOptions.SmtpPort;
            smtpClient.EnableSsl = sendingOptions.UseSSL;
            smtpClient.Credentials = new NetworkCredential(sendingOptions.Login, sendingOptions.Password);

        }

        private static void FormMail()
        {
            foreach (string mailAttachment in mailAttachments)
                sendingMail.Attachments.Add(new Attachment(mailAttachment));

            foreach (MailAddress mailRecepient in mailRecipients)
                sendingMail.To.Add(mailRecepient);
        }

        public static void Send()
        {
            SetSendingOptions();
            FormMail();

            smtpClient.Send(sendingMail);
        }
    }
}
