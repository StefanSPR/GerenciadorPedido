using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dto.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedido.Web.Controllers
{
    public class ClienteController : Controller
    {
        #region CONSTRUTOR
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        #endregion
        #region VIEWS
        public IActionResult Index()
        {
            var clientes = _clienteService.SelecionarTodos();
            return View(clientes);
        }
        public IActionResult Create()
        {
            return View("Cadastro");
        }
        public IActionResult Edit(int id)
        {
            var model = _clienteService.ObterPorId(id);
            if (model == null) return NotFound();
            return View("Cadastro", model);
        }
        #endregion
        #region Requests
        [HttpGet]
        public JsonResult GetPesquisar(string descricao)
        {
            IEnumerable<ClienteModel> models = _clienteService.SelecionarPorNomeEmail(descricao);
            return Json(models);
        }

        [HttpGet]
        public JsonResult GetId(int id)
        {
            ClienteModel models = _clienteService.ObterPorId(id);
            return Json(models);
        }
        [HttpPost]
        public IActionResult Create(CrtCliente model)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro");
            }

            _clienteService.Inserir(_mapper.Map<ClienteModel>(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(UpdCliente upd)
        {
            if (!ModelState.IsValid)
            {
                var model = _clienteService.ObterPorId(upd.Id);
                return View("Cadastro", model);
            }

            _clienteService.Atualizar(upd.Id, _mapper.Map<ClienteModel>(upd));
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public NoContentResult Delete(int id)
        {
            _clienteService.Apagar(id);
            return NoContent();
        }
        #endregion
    }
}
