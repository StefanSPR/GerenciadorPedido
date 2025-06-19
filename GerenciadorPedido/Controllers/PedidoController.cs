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
        public IActionResult Visualizar(int id)
        {
            ViewBag.Id = id;
            return View("Cadastro");
        }
        #endregion
        #region Requests
        [HttpGet]
        public JsonResult GetPesquisar(StatusPedidoEnum? status, int? clienteId)
        {
            IEnumerable<PedidoModel> pedidos = _pedidoService.SelecionarPorStatusECliente(status, clienteId);
            return Json(pedidos);
        }
        [HttpGet]
        public JsonResult GetId(int id)
        {
            var pedido = _pedidoService.ObterPorId(id);
            return Json(pedido);
        }
        [HttpPost]
        public IActionResult Inserir(CrtPedido pedido)
        {
            var id = _pedidoService.Inserir(_mapper.Map<PedidoModel>(pedido));
            return Json(id);
        }
        [HttpPut]
        public NoContentResult Avancar([FromRoute]int id)
        {
            _pedidoService.Avancar(id);
            return NoContent();
        }
        #endregion
    }
}
