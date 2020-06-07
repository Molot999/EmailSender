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
using EmailSender.Model;

namespace EmailSender.ViewModel
{
    class OptionsViewModel : INotifyPropertyChanged
    {
        private string smtpHost;
        private string smtpPort;
        private string login;
        private string password;
        private bool useSSL;

        public string SmtpHost { get => smtpHost; set => smtpHost = value; }
        public string SmtpPort { get => smtpPort; set => smtpPort = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public bool UseSSL { get => useSSL; set => useSSL = value; }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
