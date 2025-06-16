using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedido.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.SelecionarTodos();
            return View(clientes);
        }
        public IActionResult Create()
        {
            return View("Cadastro");
        }

        [HttpPost]
        public IActionResult Create(ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro");
            }

            _clienteService.Inserir(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _clienteService.ObterPorId(id);
            if (model == null) return NotFound();
            return View("Cadastro", model);
        }

        [HttpPost]
        public IActionResult Edit(ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _clienteService.ObterPorId(model.Id);
                return View("Cadastro", model);
            }

            _clienteService.Atualizar(model.Id, model);
            return RedirectToAction(nameof(Index));
        }
    }
}
