CREATE TABLE [dbo].[Pedido]
(
	[Id]				INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ClienteId]			INT NOT NULL,
	[ValorTotal]		DECIMAL(18,2) NOT NULL,
	[PedidoStatus]		INT NOT NULL DEFAULT 0,
	[DataCadastro]		DATETIME2 DEFAULT GETDATE(),
	
    CONSTRAINT FK_Cliente_Pedido FOREIGN KEY (ClienteId)
    REFERENCES Cliente(Id)
)
