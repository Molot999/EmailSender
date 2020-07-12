using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmailSender.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MessageContentViewModel MessageContentViewModel { get; set; } = new MessageContentViewModel();
        public MessageAttachmentsViewModel MessageAttachmentsViewModel { get; set; }  = new MessageAttachmentsViewModel();
        public MessageRecipientsViewModel MessageRecepientsViewModel { get; set; }  = new MessageRecipientsViewModel();
        public OptionsViewModel OptionsViewModel { get; set; } = new OptionsViewModel();


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
