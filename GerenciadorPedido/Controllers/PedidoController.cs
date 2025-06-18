using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dto.Pedido;
using GerenciadorPedido.Shared.Enum;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorPedido.Web.Controllers
{
    public class PedidoController : Controller
    {
        #region Construtor
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        #endregion
        #region Views
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("Cadastro");
        }
        public IActionResult Edit(int id)
        {
            var model = _pedidoService.ObterPorId(id);
            if (model == null) return NotFound();
            return View("Cadastro", model);
        }

        #endregion
        #region Requests
        [HttpGet]
        public JsonResult GetPesquisar(StatusPedidoEnum? status, int? clienteId)
        {
            IEnumerable<PedidoModel> pedidos = _pedidoService.SelecionarPorStatusECliente(status, clienteId);
            return Json(pedidos);
        }
        [HttpPost]
        public IActionResult Inserir(CrtPedido pedido)
        {
            _pedidoService.Inserir(_mapper.Map<PedidoModel>(pedido));
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Editar(PedidoModel pedido)
        {
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
