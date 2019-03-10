CREATE TABLE [dbo].[TiposDeConta]
(
	[ID]            UNIQUEIDENTIFIER NOT NULL,
	[Descricao]     VARCHAR(20) NOT NULL,
	CONSTRAINT [PK_TiposDeConta] PRIMARY KEY ([ID])
)
