using AutoMapper;
using GerenciadorPedido.Application.Interface.Base;
using GerenciadorPedido.Application.ViewModel.Base;
using GerenciadorPedido.Dominio.Base;
using GerenciadorPedido.Infra.Interface.Base;

namespace GerenciadorPedido.Application.Service.Base
{
    public abstract class ServiceBase<T, TDominio> : IServiceBase<T> where T : BaseModelId where TDominio : BaseId
    {
        protected readonly IRepositoryBase<TDominio> _repositorio;
        protected readonly IMapper _mapper;

        protected ServiceBase(IRepositoryBase<TDominio> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #region Public
        public virtual void Apagar(int id)
        {
            _repositorio.Delete(id);
        }

        public virtual void Atualizar(int id, T upd)
        {
            Validar(upd);
            ValidarAtualizar(upd);
            TDominio dominio = _mapper.Map<TDominio>(upd);
            dominio.Id = id;
            _repositorio.Update(dominio);
        }

        public virtual int Inserir(T create)
        {
            TDominio dominio = _mapper.Map<TDominio>(create);
            Validar(create);
            ValidarInserir(create);
            return _repositorio.Insert(dominio);
        }

        public virtual T ObterPorId(int id)
        {
            var domminio = _repositorio.GetById(id);
            return _mapper.Map<T>(domminio);
        }

        public virtual IList<T> SelecionarTodos()
        {
            return _mapper.Map<IList<T>>(_repositorio.GetAll());
        }
        #endregion
        #region Protected
        protected abstract void Validar(T model);
        protected abstract void ValidarInserir(T model);
        protected abstract void ValidarAtualizar(T model);
        #endregion
    }
}
