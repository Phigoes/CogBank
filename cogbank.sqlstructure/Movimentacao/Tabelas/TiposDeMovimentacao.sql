CREATE TABLE [dbo].[TiposDeMovimentacao]
(
	[ID]            UNIQUEIDENTIFIER NOT NULL,
	[Descricao]     VARCHAR(20) NOT NULL,
	CONSTRAINT [PK_TiposDeMovimentacao] PRIMARY KEY ([ID])
)
