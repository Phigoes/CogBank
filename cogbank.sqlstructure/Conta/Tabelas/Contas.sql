CREATE TABLE [dbo].[Contas]
(
	[ID]            UNIQUEIDENTIFIER NOT NULL,
	[Numero]        INT NOT NULL,
	[NomeDoTitular] VARCHAR(100) NOT NULL,
    [Saldo]         DECIMAL(18,2) NOT NULL,
	[TipoDeContaID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Contas] PRIMARY KEY ([ID]),
	CONSTRAINT [UK_Contas_Nome] UNIQUE ([Numero]),
	CONSTRAINT [Relacionamento_Contas_TiposDeConta] FOREIGN KEY ([TipoDeContaID]) REFERENCES [dbo].[TiposDeConta] ([ID]) ON DELETE CASCADE
)
