using System;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EmailSender.Command;
using System.Net.Mail;

namespace EmailSender.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<MailMessage> MailCollection { get; set; }

        private string mailSender;
        private string mailRecipient;
        private string mailSubject;
        private string mailBody;

        public string MailSender { get { return mailSender; } set { mailSender = value; } }
        public string MailRecipient { get { return mailRecipient; } set { mailRecipient = value; } }
        public string MailSubject { get { return mailSubject; } set { mailSubject = value; } }
        public string MailBody { get { return mailBody; } set { mailBody = value; } }


        private SimpleCommand sendEmail;
        public SimpleCommand SendEmail
        {
            get
            {
                return sendEmail ??
                    (sendEmail = new SimpleCommand(obj =>
                    {
                        MailMessage newMail = new MailMessage(mailSender, mailRecipient, mailSubject, mailBody);
                        
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
