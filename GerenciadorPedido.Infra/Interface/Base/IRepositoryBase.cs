namespace GerenciadorPedido.Infra.Interface.Base
{
    public interface IRepositoryBase<T> 
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
