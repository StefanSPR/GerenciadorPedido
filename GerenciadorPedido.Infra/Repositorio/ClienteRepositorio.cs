﻿using Dapper;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;

namespace GerenciadorPedido.Infra.Repositorio
{
    public class ClienteRepositorio : RepositoryBase<ClienteDominio>, IClienteRepositorio
    {
        public ClienteRepositorio(Contexto contexo) : base(contexo)
        {
        }

        protected override string TableName => "CLIENTE";

        public IEnumerable<ClienteDominio> GetByNameEmail(string descricao)
        {
            return _contexo.Connection.Query<ClienteDominio>($"SELECT Id, Nome, Email, Telefone, DataCadastro FROM {TableName} WHERE Nome LIKE @Descricao OR Email LIKE @Descricao", new { Descricao = $"%{descricao}%" }).ToList();
        }
        public override ClienteDominio? GetById(int id)
        {
            return _contexo.Connection.QuerySingle<ClienteDominio>($"SELECT Id, Nome, Email, Telefone, DataCadastro FROM {TableName} WHERE Id = @Id", new { Id = id });
        }
        public override int Insert(ClienteDominio entity)
        {
            string cmd = @"INSERT INTO [Cliente] ([Nome], [Email], [Telefone])
                VALUES
                (@Nome, @Email, @Telefone)
                SELECT @@Identity";
            return _contexo.Connection.QuerySingle<int>(cmd, new { entity.Nome, entity.Email, entity.Telefone });
        }

        public override void Update(ClienteDominio entity)
        {
            string cmd = @"UPDATE [Cliente] SET [Nome] = @Nome, [Email] = Email, [Telefone] = @Telefone
                WHERE Id = @Id";
            _contexo.Connection.Execute(cmd, new { entity.Id, entity.Nome, entity.Email, entity.Telefone });
        }

    }
}
