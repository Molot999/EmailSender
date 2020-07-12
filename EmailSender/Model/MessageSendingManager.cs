using System.Net.Mail;
using System.Net;
using System.Collections.ObjectModel;

namespace EmailSender.Model
{
    static class MessageSendingManager
    {
        public static bool IsRecipientsSet => MailRecipients.Count != 0;

        public static bool IsSendingOptionsSet => SendingOptions != null;

        public static SmtpOptions SendingOptions { private get; set; }

        public static SmtpClient SmtpClient { get; } = new SmtpClient();

        public static ObservableCollection<string> MailAttachments { get; set; } = new ObservableCollection<string>();

        public static ObservableCollection<MailAddress> MailRecipients { get; set; } = new ObservableCollection<MailAddress>();

        public static MailMessage SendingMail { private get;  set; }

        private static void ApplySendingOptions()
        {
           
            SmtpClient.Credentials = new NetworkCredential(SendingOptions.Login, SendingOptions.Password);
            
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            SmtpClient.Host = SendingOptions.SmtpHost;
            SmtpClient.Port = SendingOptions.SmtpPort;
            SmtpClient.EnableSsl = SendingOptions.UseSSL;
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
            ApplySendingOptions();
            FormMail();

            await SmtpClient.SendMailAsync(SendingMail);
        }

    }
}
