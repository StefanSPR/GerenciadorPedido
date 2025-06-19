use GerenciadorPedido
CREATE TABLE [dbo].[Cliente]
(
	[Id]			INT NOT NULL IDENTITY(1,1)PRIMARY KEY,
	[Nome]			VARCHAR(255),
	[Email]			VARCHAR(255),
	[Telefone]		VARCHAR(20),
	[DataCadastro]	DATETIME2 DEFAULT GETDATE()
)
CREATE TABLE [dbo].[Produto]
(
	[Id]				INT NOT NULL IDENTITY(1,1)PRIMARY KEY,
	[Nome]				VARCHAR(255),
	[Descricao]			VARCHAR(1000),
	[Preco]				DECIMAL(18,2),
	[QuantidadeEstoque] INT
)


CREATE TABLE [dbo].[Pedido]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ClienteId] INT NOT NULL,
	[ValorTotal] DECIMAL(18,2) NOT NULL,
	[PedidoStatus] INT NOT NULL DEFAULT 0,
	[DataCadastro] DATETIME2 DEFAULT GETDATE(),
	
    CONSTRAINT FK_Cliente_Pedido FOREIGN KEY (ClienteId)
    REFERENCES Cliente(Id)
)
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
go
INSERT INTO [dbo].[Cliente] ([Nome], [Email], [Telefone])
VALUES
('João da Silva', 'joao.silva@email.com', '(11) 91234-5678'),
('Maria Oliveira', 'maria.oliveira@email.com', '(21) 99876-5432'),
('Carlos Souza', 'carlos.souza@email.com', '(31) 93456-7890'),
('Ana Paula', 'ana.paula@email.com', '(41) 98765-4321'),
('Fernando Lima', 'fernando.lima@email.com', '(51) 95678-1234'),
('Juliana Rocha', 'juliana.rocha@email.com', '(61) 92345-6789'),
('Bruno Mendes', 'bruno.mendes@email.com', '(71) 99812-3456'),
('Patrícia Gomes', 'patricia.gomes@email.com', '(81) 94567-8901'),
('Lucas Ribeiro', 'lucas.ribeiro@email.com', '(91) 96789-0123'),
('Larissa Costa', 'larissa.costa@email.com', '(85) 97890-1234');

INSERT INTO [dbo].[Produto] ([Nome], [Descricao], [Preco], [QuantidadeEstoque])
VALUES
('Notebook Dell Inspiron 15', 'Notebook com processador Intel Core i7, 16GB RAM, SSD 512GB, tela 15.6"', 4599.90, 25),
('Smartphone Samsung Galaxy S22', 'Celular com 128GB, 8GB RAM, câmera tripla e Android 13', 3799.00, 50),
('Mouse Logitech M170', 'Mouse sem fio, design ergonômico, conexão USB', 89.90, 150),
('Monitor LG 24" LED', 'Monitor Full HD 1920x1080, painel IPS, HDMI e VGA', 899.99, 40),
('Teclado Mecânico Redragon Kumara', 'Teclado gamer com switches Outemu Blue, iluminação RGB', 259.00, 70),
('Impressora HP DeskJet Ink Advantage 2776', 'Multifuncional com Wi-Fi, impressão colorida e scanner', 399.90, 35),
('Cadeira Gamer ThunderX3', 'Cadeira com design ergonômico, apoio de braço ajustável, base reforçada', 1199.00, 10),
('HD Externo Seagate 2TB', 'Armazenamento portátil USB 3.0, compatível com Windows e Mac', 499.90, 60),
('Pen Drive Kingston 64GB', 'Alta velocidade de leitura e gravação, interface USB 3.1', 49.90, 200),
('Fonte Corsair 650W 80 Plus Bronze', 'Fonte ATX para PC, alta eficiência energética', 429.00, 20);
