using ChatApp.MAUI.ViewModels;

namespace ChatApp.MAUI.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }
    }
}
