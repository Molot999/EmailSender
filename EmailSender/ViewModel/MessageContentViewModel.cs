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
using System.Windows.Media.Animation;
using System.Windows.Forms;


namespace EmailSender.ViewModel
{
    class MessageContentViewModel : INotifyPropertyChanged
    {
        private MailMessage sendingMail = new MailMessage();
        public string SubjectOfMail
        {
            get { return sendingMail.Subject; }

            set
            {
                sendingMail.Subject = value;
                OnPropertyChanged("SubjectOfMail");
            }
        }

        public string SenderOfEmail
        {
            get { return sendingMail.Sender?.ToString(); }

            set
            {
                sendingMail.Sender = new MailAddress(value.ToLower().Replace(" ", ""));
                OnPropertyChanged("SenderOfEmail");
            }
        }

        public string NameOfSender
        {
            get { return sendingMail.From?.ToString(); }

            set
            {
                sendingMail.From = new MailAddress(value);
                OnPropertyChanged("NameOfSender");
            }
        }

        public string BodyOfMail
        {
            get { return sendingMail.Body; }

            set
            {
                sendingMail.Body = value;
                OnPropertyChanged("BodyOfMail");
            }
        }

        public bool IsBodyHtml
        {
            get { return sendingMail.IsBodyHtml; }

            set
            {
                sendingMail.IsBodyHtml = value;
                OnPropertyChanged("IsBodyHtml");
            }
        }

        private SimpleCommand sendMail;
        public SimpleCommand SendMail
        {
            get
            {
                return sendMail ??
                    (sendMail = new SimpleCommand(obj =>
                    {
                        MessageSendingManager.SetMailMessage(sendingMail);
                        MessageSendingManager.Send();
                    }
                    ));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
