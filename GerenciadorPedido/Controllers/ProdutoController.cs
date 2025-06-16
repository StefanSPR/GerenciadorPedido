using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedido.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var produtos = _produtoService.SelecionarTodos();
            return View(produtos);
        }
        public IActionResult Create()
        {
            return View("Cadastro");
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro");
            }

            _produtoService.Inserir(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _produtoService.ObterPorId(id);
            if (model == null) return NotFound();
            return View("Cadastro", model);
        }

        [HttpPost]
        public IActionResult Edit(ProdutoModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _produtoService.ObterPorId(model.Id);
                return View("Cadastro", model);
            }

            _produtoService.Atualizar(model.Id, model);
            return RedirectToAction(nameof(Index));
        }
    }
}
