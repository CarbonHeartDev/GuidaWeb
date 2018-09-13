USE [TuoDB]
GO

/****** Object:  Table [dbo].[Env]    Script Date: 13/09/2018 02:10:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Env](
	[K] [varchar](200) NOT NULL,
	[V] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Env] PRIMARY KEY CLUSTERED 
(
	[K] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [TuoDB]
GO

INSERT INTO Env(K,V) VALUES('MD5(password)','c21f969b5f03d33d43e04f8f136e7682');
GO
USE [TuoDB]
GO

/****** Object:  Table [dbo].[PagineH]    Script Date: 13/09/2018 02:16:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PagineH](
	[Id] [varchar](100) NOT NULL,
	[Contenuto] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PagineH] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [TuoDB]
GO

INSERT INTO PagineH(Id,Contenuto) VALUES('Home','<h1>GuidaWeb</h1><p>Benvenuto in GuidaWeb, per cominciare fai login con la password "default" (senza virgolette) nella sezione "Amministrazione" dove potrai creare o caricare le schede, creare nuove pagine statiche e sostituire questa pagina (presente nella lista delle pagine statiche con titolo "Home" con una home page personalizzata). Si consiglia inoltre di entrare nel menu "Configurazione" (tramite il link presente in fondo alla sezione Amministrazione) per sostituire la password di default con una parola chiave più sicura e per impostare un titolo personalizzato per l''applicazione.</p>');
GO
USE [TuoDB]
GO

/****** Object:  Table [dbo].[Schede]    Script Date: 13/09/2018 02:16:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schede](
	[Id] [int] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[Descrizione] [varchar](max) NULL,
	[Immagine] [varchar](max) NULL,
	[Audio] [varchar](max) NULL,
 CONSTRAINT [PK_Schede] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

