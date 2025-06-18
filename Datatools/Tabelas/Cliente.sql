﻿CREATE TABLE [dbo].[Cliente]
(
	[Id]			INT NOT NULL IDENTITY(1,1)PRIMARY KEY,
	[Nome]			VARCHAR(255),
	[Email]			VARCHAR(255),
	[Telefone]		VARCHAR(20),
	[DataCadastro]	DATETIME2 DEFAULT GETDATE()
)
