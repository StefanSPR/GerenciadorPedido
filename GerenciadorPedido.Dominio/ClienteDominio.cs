using GerenciadorPedido.Dominio.Base;

namespace GerenciadorPedido.Dominio
{
    public class ClienteDominio : BaseId
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } 
    }
}
