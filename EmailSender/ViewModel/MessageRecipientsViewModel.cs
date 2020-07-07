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
    class MessageRecipientsViewModel : INotifyPropertyChanged
    {
        private string newRecipientMailTextBox;
        public string NewRecipientMailTextBox
        {
            get
            {
                return newRecipientMailTextBox;
            }

            set
            {
                newRecipientMailTextBox = value.ToLower().Replace(" ", "");
                OnPropertyChanged("NewRecipientMailTextBox");
            }
        }

        public ObservableCollection<MailAddress> MailRecipients
        {
            get
            {
                return MessageSendingManager.MailRecipients;
            }

            set
            {
                MessageSendingManager.MailRecipients = value;
            }
        }

        private MailAddress selectedRecipientMail;
        public MailAddress SelectedRecipientMail
        {
            get { return selectedRecipientMail; }

            set
            {
                selectedRecipientMail = value;
                OnPropertyChanged("SelectedRecipientMail");
            }
        }

        private SimpleCommand exportRecipientMail;
        public SimpleCommand ExportRecipientMail
        {
            get
            {
                return exportRecipientMail ??
                    (exportRecipientMail = new SimpleCommand(obj =>
                    {
                        OpenFileDialog OPF = new OpenFileDialog();
                        OPF.Filter = "Файлы txt|*.txt";

                        if (OPF.ShowDialog() == DialogResult.OK)
                        {
                            StreamReader readFile = File.OpenText(OPF.FileName);

                            string newRecipient;

                            while ((newRecipient = readFile.ReadLine()) != null)
                            {
                                MailAddress newRecipientMail;

                                try
                                {
                                    newRecipientMail = new MailAddress(newRecipient);
                                }
                                catch
                                {
                                    continue;
                                }

                                MailRecipients.Add(newRecipientMail);
                            }

                        }
                        
                    }));
            }
        }

        private SimpleCommand addRecipientMail;
        public SimpleCommand AddRecipientMail
        {
            get
            {
                return addRecipientMail ??
                    (addRecipientMail = new SimpleCommand(obj =>
                    {
                        try
                        {
                            MailAddress newReceptionMail = new MailAddress(NewRecipientMailTextBox);
                            MailRecipients.Add(newReceptionMail);
                            NewRecipientMailTextBox = "";
                        }
                        catch
                        {
                            throw new Exception();
                        }

                    }, (obj) => 
                    {
                        try
                        {
                            MailAddress newReciptionMail = new MailAddress(newRecipientMailTextBox);
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    ));
            }
        }

        private SimpleCommand deleteRecipientMail;
        public SimpleCommand DeleteRecipientMail
        {
            get
            {
                return deleteRecipientMail ??
                    (deleteRecipientMail = new SimpleCommand(obj =>
                    {
                        MailRecipients.Remove(SelectedRecipientMail);

                        if (MailRecipients.Count != 0)
                            SelectedRecipientMail = MailRecipients[0];

                    }, (obj) => SelectedRecipientMail != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
