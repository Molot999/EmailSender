﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EmailSender.Command;
using EmailSender.Model;
using System.Windows.Forms;

namespace EmailSender.ViewModel
{
    class MessageAttachmentsViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<string> MailAttachments
        {
            get
            {
                return MessageSendingManager.MailAttachments;
            }

            set
            {
                MessageSendingManager.MailAttachments = value;
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
                            MailAttachments.Add(attachmentFileName);
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

                        MailAttachments.Remove(SelectedAttachment);

                        if (MailAttachments.Count != 0)
                            SelectedAttachment = MailAttachments[0];

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
