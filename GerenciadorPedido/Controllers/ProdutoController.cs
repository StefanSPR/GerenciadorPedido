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
        public IActionResult Create(CrtProduto model)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro");
            }

            _produtoService.Inserir(_mapper.Map<ProdutoModel>(model));
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _produtoService.ObterPorId(model.Id);
                return View("Cadastro", model);
            }

            _produtoService.Atualizar(model.Id, _mapper.Map<ProdutoModel>(model));
            return RedirectToAction(nameof(Index));
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
