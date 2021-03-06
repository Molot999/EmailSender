﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailSender.Command;
using EmailSender.Model;

namespace EmailSender.ViewModel
{
    class OptionsViewModel : INotifyPropertyChanged
    {
        public SmtpOptions OptionsOfSending { get; set; } = new SmtpOptions();

        public string SmtpHost { get => OptionsOfSending.SmtpHost; set { OptionsOfSending.SmtpHost = value; OnPropertyChanged("SmtpHost"); }}
        public int SmtpPort { get => OptionsOfSending.SmtpPort; set { OptionsOfSending.SmtpPort = value; OnPropertyChanged("SmtpPort"); }}
        public string Login { get => OptionsOfSending.Login; set { OptionsOfSending.Login = value; OnPropertyChanged("Login"); }}
        public string Password { get => OptionsOfSending.Password; set { OptionsOfSending.Password = value; OnPropertyChanged("Password"); }}
        public bool UseSSL { get => OptionsOfSending.UseSSL; set { OptionsOfSending.UseSSL = value; OnPropertyChanged("UseSSL"); }}

        private SimpleCommand saveOptions;
        public SimpleCommand SaveOptions
        {
            get
            {
                return saveOptions ??
                    (saveOptions = new SimpleCommand(obj =>
                    {
                        SmtpOptionsFileManager.SaveOptionsToFile(OptionsOfSending);

                        MessageSendingManager.SendingOptions = OptionsOfSending;
                        
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
                        (SmtpHost, SmtpPort, Login, Password, UseSSL) = SmtpOptionsFileManager.UploadOptionsFromFile();
                        MessageSendingManager.SendingOptions = OptionsOfSending;

                    }, obj => SmtpOptionsFileManager.OptionsFileExists));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
