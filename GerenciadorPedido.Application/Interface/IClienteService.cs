﻿using GerenciadorPedido.Application.Interface.Base;
using GerenciadorPedido.Application.ViewModel;

namespace GerenciadorPedido.Application.Interface
{
    public interface IClienteService : IServiceBase<ClienteModel>
    {
        IEnumerable<ClienteModel> SelecionarPorNomeEmail(string descricao);
    }
}
