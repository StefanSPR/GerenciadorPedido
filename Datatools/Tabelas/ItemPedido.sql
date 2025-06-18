CREATE TABLE [dbo].[ItemPedido]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[PedidoId] INT NOT NULL,
	[ProdutoId] INT NOT NULL,
	[Quantidade] INT NOT NULL,
	[PrecoUnitario] DECIMAL(18,2) NOT NULL,
	
    CONSTRAINT FK_Pedido_ItemPedido FOREIGN KEY (PedidoId)
    REFERENCES Pedido(Id),
    CONSTRAINT FK_Produto_ItemPedido FOREIGN KEY (ProdutoId)
    REFERENCES Produto(Id),
)
