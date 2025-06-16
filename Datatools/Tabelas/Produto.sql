CREATE TABLE [dbo].[Produto]
(
	[Id]				INT NOT NULL IDENTITY(1,1),
	[Nome]				VARCHAR(255),
	[Descricao]			VARCHAR(1000),
	[Preco]				DECIMAL(18,2),
	[QuantidadeEstoque] INT
)
