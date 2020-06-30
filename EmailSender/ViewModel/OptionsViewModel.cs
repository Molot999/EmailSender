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
    class OptionsViewModel : INotifyPropertyChanged
    {
        private Options options = new Options(); //{ get => MessageSendManager.OptionsOfMailSending; set => MessageSendManager.OptionsOfMailSending = value; }

        public string SmtpHost { get => options.SmtpHost; set { options.SmtpHost = value; OnPropertyChanged("SmtpHost"); }}
        public int SmtpPort { get => options.SmtpPort; set { options.SmtpPort = value; OnPropertyChanged("SmtpPort"); }}
        public string Login { get => options.Login; set { options.Login = value; OnPropertyChanged("Login"); }}
        public string Password { get => options.Password; set { options.Password = value; OnPropertyChanged("Password"); }}
        public bool UseSSL { get => options.UseSSL; set { options.UseSSL = value; OnPropertyChanged("UseSSL"); }}

        private SimpleCommand saveOptions;
        public SimpleCommand SaveOptions
        {
            get
            {
                return saveOptions ??
                    (saveOptions = new SimpleCommand(obj =>
                    {

                        OptionsFileManager.SaveOptionsToFile(options);

                    }, obj => !string.IsNullOrEmpty(SmtpHost) && SmtpPort != 0));
            }
        }

        private SimpleCommand uploadLastOptions;
        public SimpleCommand UploadLastOptions
        {
            get
            {
                return uploadLastOptions ??
                    (uploadLastOptions = new SimpleCommand(obj =>
                    {
                        options = OptionsFileManager.UploadOptionsFromFile();

                    }, obj => OptionsFileManager.OptionsFileExists));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
