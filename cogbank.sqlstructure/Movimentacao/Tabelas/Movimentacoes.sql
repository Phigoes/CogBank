CREATE TABLE [dbo].[Movimentacoes]
(
	[ID]                   UNIQUEIDENTIFIER NOT NULL,
	[Valor]                DECIMAL(18,2) NOT NULL,
	[DataDaMovimentacao]   DATETIME NOT NULL,
	[ContaID]              UNIQUEIDENTIFIER NOT NULL,
	[TipoDeMovimentacaoID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_Movimentacoes] PRIMARY KEY ([ID]),
	CONSTRAINT [Relacionamento_Movimentacoes_Contas] FOREIGN KEY ([ContaID]) REFERENCES [dbo].[Contas] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [Relacionamento_Movimentacoes_TipoDeMovimentacao] FOREIGN KEY ([TipoDeMovimentacaoID]) REFERENCES [dbo].[TiposDeMovimentacao] ([ID]) ON DELETE CASCADE
)
