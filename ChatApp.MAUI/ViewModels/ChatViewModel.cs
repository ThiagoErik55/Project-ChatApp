using System.Collections.ObjectModel;
using System.Windows.Input;
using ChatApp.Model.Messages;

namespace ChatApp.MAUI.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public ObservableCollection<Mensagem> Mensagens { get; set; }
        public string NovaMensagem { get; set; }

        public ICommand EnviarMensagemCommand { get; }

        public ChatViewModel()
        {
            Mensagens = new ObservableCollection<Mensagem>
            {
                new Mensagem { Conteudo = "Oi, tudo bem?", DataEnvio = DateTime.Now.AddMinutes(-10), IsIncoming = true },
                new Mensagem { Conteudo = "Tudo �timo! E voc�?", DataEnvio = DateTime.Now.AddMinutes(-8), IsIncoming = false },
                new Mensagem { Conteudo = "Estou bem, obrigado!", DataEnvio = DateTime.Now.AddMinutes(-5), IsIncoming = true }
            };

            EnviarMensagemCommand = new Command(EnviarMensagem);
        }

        private void EnviarMensagem()
        {
            if (!string.IsNullOrWhiteSpace(NovaMensagem))
            {
                Mensagens.Add(new Mensagem
                {
                    Conteudo = NovaMensagem,
                    DataEnvio = DateTime.Now,
                    IsIncoming = false
                });
                NovaMensagem = string.Empty;
                OnPropertyChanged(nameof(NovaMensagem));
            }
        }
    }
}
