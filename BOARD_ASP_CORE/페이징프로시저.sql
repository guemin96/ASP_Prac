USE [DotNetNote]
GO
/****** Object:  StoredProcedure [dbo].[NEW_PagingNote]    Script Date: 2022-11-18 오후 1:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[2] 게시판(DotNetNote)에서 데이터 출력 : ListNotes
ALTER Procedure [dbo].[NEW_PagingNote]
    @IStartCount Int
	,@IEndCount Int
As
  select *
  From
  (select ROW_NUMBER() OVER (Order by id desc) as rowNum, id, Name,Title, PostDate, ReadCount
  from TB_Notes)B
  where b.rowNum Between @IStartCount and @IEndCount
