namespace GerenciadorPedido.Application.Interface.Base
{
    public interface IServiceBase<T> where T : class
    {
        public void Apagar(int id);
        public int Inserir(T create);
        public T ObterPorId(int id);
        public void Atualizar(int id, T upd);
        public IList<T> SelecionarTodos();
    }
}
