using System.ComponentModel;

namespace GerenciadorPedido.Shared.Enum
{
    public enum StatusPedidoEnum
    {
        [Description("Novo")]
        Novo = 0,
        [Description("Processando")]
        Processando = 1,
        [Description("Finalizado")]
        Finalizado = 2,
    }
}
