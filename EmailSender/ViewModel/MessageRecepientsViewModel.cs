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
    class MessageRecepientsViewModel : INotifyPropertyChanged
    {
        private string newRecepientMailTextBox;
        public string NewRecepientMailTextBox
        {
            get
            {
                return newRecepientMailTextBox;
            }

            set
            {
                newRecepientMailTextBox = value.ToLower().Replace(" ", "");
                OnPropertyChanged("NewRecepientMailTextBox");
            }
        }

        private ObservableCollection<MailAddress> recepientsMails = new ObservableCollection<MailAddress>();
        public ObservableCollection<MailAddress> RecepientsMails
        {
            get
            {
                return recepientsMails;
            }

            set
            {
                recepientsMails = value;
            }
        }

        private MailAddress selectedRecepientMail;
        public MailAddress SelectedRecepientMail
        {
            get { return selectedRecepientMail; }

            set
            {
                selectedRecepientMail = value;
                OnPropertyChanged("SelectedRecepientMail");
            }
        }

        private SimpleCommand exportRecepientMail;
        public SimpleCommand ExportRecepientMail
        {
            get
            {
                return exportRecepientMail ??
                    (exportRecepientMail = new SimpleCommand(obj =>
                    {
                        OpenFileDialog OPF = new OpenFileDialog();
                        OPF.Filter = "Файлы txt|*.txt";

                        if (OPF.ShowDialog() == DialogResult.OK)
                        {
                            StreamReader readFile = File.OpenText(OPF.FileName);

                            string newRecepient;

                            while ((newRecepient = readFile.ReadLine()) != null)
                            {
                                MailAddress newRecepientMail;

                                try
                                {
                                    newRecepientMail = new MailAddress(newRecepient);
                                }
                                catch
                                {
                                    continue;
                                }

                                RecepientsMails.Add(newRecepientMail);
                            }
                        }
                        
                    }));
            }
        }

        private SimpleCommand addRecepientMail;
        public SimpleCommand AddRecepientMail
        {
            get
            {
                return addRecepientMail ??
                    (addRecepientMail = new SimpleCommand(obj =>
                    {
                        try
                        {
                            MailAddress newReceptionMail = new MailAddress(NewRecepientMailTextBox);
                            RecepientsMails.Add(newReceptionMail);
                            NewRecepientMailTextBox = "";
                        }
                        catch
                        {
                            throw new Exception();
                        }

                    }, (obj) => 
                    {
                        try
                        {
                            MailAddress newReceprionMail = new MailAddress(newRecepientMailTextBox);
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

        private SimpleCommand deleteRecepientMail;
        public SimpleCommand DeleteRecepientMail
        {
            get
            {
                return deleteRecepientMail ??
                    (deleteRecepientMail = new SimpleCommand(obj =>
                    {
                        RecepientsMails.Remove(SelectedRecepientMail);

                        if (RecepientsMails.Count != 0)
                            SelectedRecepientMail = RecepientsMails[0];

                    }, (obj) => SelectedRecepientMail != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
