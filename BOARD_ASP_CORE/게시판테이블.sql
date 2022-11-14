USE [DotNetNote]
GO

/****** Object:  Table [dbo].[TB_Notes]    Script Date: 2022-11-14 ¿ÀÈÄ 5:16:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](25) NULL,
	[Title] [nvarchar](150) NULL,
	[ReadCount] [int] NULL,
	[PostDate] [datetime] NULL,
	[Content] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


