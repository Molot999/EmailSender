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
        public MessageAttachmentsViewModel MessageAttachmentsViewModel { get; set; }  = new MessageAttachmentsViewModel();
        public MessageRecepientsViewModel RecepientsViewModel { get; set; }  = new MessageRecepientsViewModel();

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
