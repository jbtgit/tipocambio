USE [TipoCambioBD]
GO

/****** Object:  Table [dbo].[TipoCambio]    Script Date: 11/03/2022 11:48:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoCambio](
	[idTipoCambio] [int] NOT NULL,
	[idMonedaOrigen] [varchar](10) NOT NULL,
	[idMonedaDestino] [varchar](10) NOT NULL,
	[valorTipoCambio] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_TipoCambio] PRIMARY KEY CLUSTERED 
(
	[idTipoCambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


