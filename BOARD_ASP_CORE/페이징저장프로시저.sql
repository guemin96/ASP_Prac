USE [DotNetNote]
GO
/****** Object:  StoredProcedure [dbo].[ListNotes]    Script Date: 2022-11-14 오후 1:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[2] 게시판(DotNetNote)에서 데이터 출력 : ListNotes
alter Procedure [dbo].NEW_PagingNote
    @IStartCount Int
	,@IEndCount Int
As
  select *
  From
  (select ROW_NUMBER() OVER (Order by PostDate desc) as rowNum, id, Name,Title, PostDate, ReadCount
  from Notes)B
  where b.rowNum Between @IStartCount and @IEndCount
