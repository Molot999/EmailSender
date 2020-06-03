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

namespace EmailSender.ViewModel
{
    class MessageAttachmentsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> attachmentCollection = new ObservableCollection<string>();
        public ObservableCollection<string> AttachmentCollection
        {
            get
            {
                return attachmentCollection;
            }
        }

        private object selectedAttachment;
        public object SelectedAttachment
        {
            get { return selectedAttachment; }

            set
            {
                selectedAttachment = value;
                OnPropertyChanged("SelectedAttachment");
            }
        }

        private SimpleCommand addAttachment;
        public SimpleCommand AddAttachment
        {
            get
            {
                return addAttachment ??
                    (addAttachment = new SimpleCommand(obj =>
                    {
                        throw new Exception();
                    }
                    ));
            }
        }

        private SimpleCommand deleteAttachment;
        public SimpleCommand DeleteAttachment
        {
            get
            {
                return deleteAttachment ??
                    (deleteAttachment = new SimpleCommand(obj =>
                    {

                    }, (obj) => SelectedAttachment != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
