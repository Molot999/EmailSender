using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EmailSender.Command;
using System.Net.Mail;
using EmailSender.Model;

namespace EmailSender.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private List<string> recepietnsMails = new List<string>();
        public List<string> RecepietnsMails { get { return recepietnsMails; } set {recepietnsMails = value; } }

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
