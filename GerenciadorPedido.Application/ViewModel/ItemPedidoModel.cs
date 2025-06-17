﻿using GerenciadorPedido.Application.ViewModel.Base;

namespace GerenciadorPedido.Application.ViewModel
{
    public class ItemPedidoModel : BaseModelId
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
