using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dto.Produto;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedido.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        #region Views
        public IActionResult Index()
        {
            var produtos = _produtoService.SelecionarTodos();
            return View(produtos);
        }
        public IActionResult Create()
        {
            return View("Cadastro");
        }
        public IActionResult Edit(int id)
        {
            var model = _produtoService.ObterPorId(id);
            if (model == null) return NotFound();
            return View("Cadastro", model);
        }

        #endregion
        #region Requests

        [HttpPost]
        public JsonResult Create(CrtProduto model)
        {
            var i =_produtoService.Inserir(_mapper.Map<ProdutoModel>(model));
            return Json(i);
        }


        [HttpPut]
        public NoContentResult Edit(UpdProduto model)
        {
            _produtoService.Atualizar(model.Id, _mapper.Map<ProdutoModel>(model));
            return NoContent();
        }

        [HttpGet]
        public JsonResult GetPesquisar(string descricao)
        {
            IEnumerable<ProdutoModel> models = _produtoService.SelecionarPorNome(descricao);
            return Json(models);
        }
        [HttpGet]
        public JsonResult GetId(int id)
        {
            ProdutoModel models = _produtoService.ObterPorId(id);
            return Json(models);
        }
        [HttpDelete]
        public NoContentResult Delete(int id)
        {
            _produtoService.Apagar(id);
            return NoContent();
        }
        #endregion
    }
}
