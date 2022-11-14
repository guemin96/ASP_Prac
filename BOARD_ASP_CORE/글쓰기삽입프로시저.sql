USE [DotNetNote]
GO

/****** Object:  StoredProcedure [dbo].[NEW_Insert_Note]    Script Date: 2022-11-14 오후 5:20:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--[2] 게시판(DotNetNote)에서 데이터 출력 : ListNotes
Create Procedure [dbo].[NEW_Insert_Note]
    @vcName nvarchar(25)
	,@vcTitle nvarchar(150)
	,@dtPostDate datetime
	,@txContent ntext
	,@iReadCount int
As
  insert into TB_Notes (Name,Title,PostDate,Content,ReadCount) values (@vcName,@vcTitle,@dtPostDate,@txContent,@iReadCount)
GO


