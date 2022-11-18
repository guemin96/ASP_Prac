USE [DotNetNote]
GO

/****** Object:  Table [dbo].[TB_User]    Script Date: 2022-11-18 ¿ÀÈÄ 1:19:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_User](
	[Num] [int] IDENTITY(1,1) NOT NULL,
	[Id] [nchar](10) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Birthday] [varchar](8) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](13) NULL,
	[Address] [varchar](100) NULL
) ON [PRIMARY]
GO


