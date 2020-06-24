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
        private MailMessage message = MessageSendManager.mailMessage;

        string subjectOfMail;
        string senderOfEmail;
        string nameOfSender;
        string bodyOfMail;
        bool isBodyHtml;

        public string SubjectOfMail
        {
            get { return subjectOfMail; }

            set
            {
                subjectOfMail = value;
                OnPropertyChanged("SubjectOfMail");
            }
        }

        public string SenderOfEmail
        {
            get { return senderOfEmail; }

            set
            {
                senderOfEmail = value.ToLower().Replace(" ", "");
                OnPropertyChanged("SenderOfEmail");
            }
        }

        public string NameOfSender
        {
            get { return nameOfSender; }

            set
            {
                nameOfSender = value;
                OnPropertyChanged("NameOfSender");
            }
        }

        public string BodyOfMail
        {
            get { return bodyOfMail; }

            set
            {
                bodyOfMail = value;
                OnPropertyChanged("BodyOfMail");
            }
        }

        public bool IsBodyHtml
        {
            get { return isBodyHtml; }

            set
            {
                isBodyHtml = value;
                OnPropertyChanged("IsBodyHtml");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
