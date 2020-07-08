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

        private static bool sendingCompletedOrNotStarted = true;
        public static bool SendingAllowed => sendingCompletedOrNotStarted == true && MailRecipients.Count > 0 && SendingOptions != null;

        public static SmtpOptions SendingOptions { private get; set; }

        private static SmtpClient smtpClient = new SmtpClient();

        public static ObservableCollection<string> MailAttachments { get; set; } = new ObservableCollection<string>();

        public static ObservableCollection<MailAddress> MailRecipients { get; set; } = new ObservableCollection<MailAddress>();

        public static MailMessage SendingMail { private get;  set; }

        private static void ApplySendingOptions()
        {
           
            smtpClient.Credentials = new NetworkCredential(SendingOptions.Login, SendingOptions.Password);
            
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Host = SendingOptions.SmtpHost;
            smtpClient.Port = SendingOptions.SmtpPort;
            smtpClient.EnableSsl = SendingOptions.UseSSL;
        }

        private static void FormMail()
        {
            foreach (string mailAttachment in MailAttachments)
                SendingMail.Attachments.Add(new Attachment(mailAttachment));

            foreach (MailAddress mailRecipient in MailRecipients)
                SendingMail.To.Add(mailRecipient);
        }

        public async static void Send()
        {
            smtpClient.SendCompleted += delegate { sendingCompletedOrNotStarted = true; };

            ApplySendingOptions();
            FormMail();

            sendingCompletedOrNotStarted = false;
            await smtpClient.SendMailAsync(SendingMail);

        }

    }
}
