using GerenciadorPedido.Application.ViewModel.Base;

namespace GerenciadorPedido.Application.ViewModel
{
    public class ClienteModel : BaseModelId
    {
        public ClienteModel(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } 
        public string DataCadastroDesc { get => DataCadastro.ToString("dd/MM/yyyy HH:mm:ss"); } 
    }
}
