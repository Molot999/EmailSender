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
    class MessageRecepientsViewModel : INotifyPropertyChanged
    {
        private List<string> recepietnsMails = new List<string>();
        public List<string> RecepietnsMails { get { return recepietnsMails; } set { recepietnsMails = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
