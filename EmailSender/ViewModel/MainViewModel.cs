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
        public MessageContentViewModel MessageContentViewModel { get; set; } = new MessageContentViewModel();
        public MessageAttachmentsViewModel MessageAttachmentsViewModel { get; set; }  = new MessageAttachmentsViewModel();
        public MessageRecepientsViewModel MessageRecepientsViewModel { get; set; }  = new MessageRecepientsViewModel();
        public OptionsViewModel OptionsViewModel { get; set; } = new OptionsViewModel();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
