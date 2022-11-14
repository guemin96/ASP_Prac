USE [DotNetNote]
GO

/****** Object:  StoredProcedure [dbo].[NEW_Update_Note]    Script Date: 2022-11-14 오후 5:20:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--[2] 게시판(DotNetNote)에서 데이터 출력 : ListNotes
CREATE Procedure [dbo].[NEW_Update_Note]
    @IId int
	,@vcName nvarchar(25)
	,@vcTitle nvarchar(150)
	,@dtPostDate datetime
	,@txContent ntext
As
Update TB_Notes 
set 
Name = @vcName
,Title = @vcTitle
,PostDate = @dtPostDate
,Content = @txContent

where Id=@IId
GO


