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
    class MessageAttachmentsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> AttachmentCollection
        {
            get
            {
                return MessageSendManager.AttachmentsOfMail;
            }

            set
            {
                MessageSendManager.AttachmentsOfMail = value;
            }
        }

        private string selectedAttachment;
        public string SelectedAttachment
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
                        OpenFileDialog OPF = new OpenFileDialog();
                        OPF.Multiselect = true;

                        if (OPF.ShowDialog() == DialogResult.OK)
                        {
                            foreach(string attachmentFileName in OPF.FileNames)
                            AttachmentCollection.Add(attachmentFileName);
                        }
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

                        AttachmentCollection.Remove(SelectedAttachment);

                        if (AttachmentCollection.Count != 0)
                            SelectedAttachment = AttachmentCollection[0];

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
