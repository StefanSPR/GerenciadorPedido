using Dapper;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;

namespace GerenciadorPedido.Infra.Repositorio
{
    public class ProdutoRepositorio : RepositoryBase<ProdutoDominio>, IProdutoRepositorio
    {
        public ProdutoRepositorio(Contexto contexo) : base(contexo)
        {
        }

        protected override string TableName => "PRODUTO";

        public IEnumerable<ProdutoDominio> GetByName(string nome)
        {
            return _contexo.Connection.Query<ProdutoDominio>($"SELECT * FROM {TableName} WHERE Nome LIKE @Nome", new { Nome = $"%{nome}%" }).ToList();
            
        }
        public override int Insert(ProdutoDominio entity)
        {
            string cmd = @"INSERT INTO [Produto] ([Nome], [Descricao], [Preco], [QuantidadeEstoque])
                VALUES
                (@Nome, @Descricao, @Preco, @QuantidadeEstoque)
                select @@Identity";
            return _contexo.Connection.Query<int>(cmd, new { entity.Nome, entity.Descricao, entity.Preco, entity.QuantidadeEstoque }).First();
        }

        public override void Update(ProdutoDominio entity)
        {
            string cmd = @"UPDATE [Produto] SET [Nome] = @Nome, [Descricao] = @Descricao, [Preco] = @Preco, [QuantidadeEstoque] = @QuantidadeEstoque
                WHERE Id = @Id";
            _contexo.Connection.Execute(cmd, new { entity.Id, entity.Nome, entity.Descricao, entity.Preco, entity.QuantidadeEstoque });

        }
    }
}
