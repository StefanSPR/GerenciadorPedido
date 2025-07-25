﻿using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface.Base;

namespace GerenciadorPedido.Infra.Interface
{
    public interface IClienteRepositorio : IRepositoryBase<ClienteDominio>
    {
        IEnumerable<ClienteDominio> GetByNameEmail(string descricao);
    }
}
