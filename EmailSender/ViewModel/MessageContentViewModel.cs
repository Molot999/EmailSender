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
        public string SubjectOfMail
        {
            get { return MessageSendManager.SendingMail.Subject; }

            set
            {
                MessageSendManager.SendingMail.Subject = value;
                OnPropertyChanged("SubjectOfMail");
            }
        }

        public string SenderOfEmail
        {
            get { return MessageSendManager.SendingMail.Sender?.ToString(); }

            set
            {
                MessageSendManager.SendingMail.Sender = new MailAddress(value.ToLower().Replace(" ", ""));
                OnPropertyChanged("SenderOfEmail");
            }
        }

        public string NameOfSender
        {
            get { return MessageSendManager.SendingMail.From?.ToString(); }

            set
            {
                MessageSendManager.SendingMail.From = new MailAddress(value);
                OnPropertyChanged("NameOfSender");
            }
        }

        public string BodyOfMail
        {
            get { return MessageSendManager.SendingMail.Body; }

            set
            {
                MessageSendManager.SendingMail.Body = value;
                OnPropertyChanged("BodyOfMail");
            }
        }

        public bool IsBodyHtml
        {
            get { return MessageSendManager.SendingMail.IsBodyHtml; }

            set
            {
                MessageSendManager.SendingMail.IsBodyHtml = value;
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
                        MessageSendManager.Send();
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
