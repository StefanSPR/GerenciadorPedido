using Dapper;
using GerenciadorPedido.Dominio.Base;
using GerenciadorPedido.Infra.Interface.Base;

namespace GerenciadorPedido.Infra.Repositorio.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseId
    {
        protected abstract string TableName { get; }
        protected readonly Contexto _contexo;

        protected RepositoryBase(Contexto contexo)
        {
            _contexo = contexo;
        }

        public virtual void Delete(int id)
        {
            _contexo.Connection.Execute($"DELETE FROM {TableName} WHERE Id = @Id", new { Id = id });
        }

        public virtual T? GetById(int id)
        {
            return _contexo.Connection.QuerySingle<T>($"SELECT * FROM {TableName} WHERE Id = @Id", new { Id = id });            
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _contexo.Connection.Query<T>($"SELECT * FROM {TableName}").ToList();            
        }

        public abstract void Update(T entity);
        public abstract int Insert(T entity);
    }
}
