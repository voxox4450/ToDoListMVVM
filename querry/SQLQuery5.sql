USE [myDb]
GO
/****** Object:  StoredProcedure [dbo].[GetNotes]    Script Date: 05.04.2024 13:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetNotes]
	
	@StatusId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		n.Id AS NoteId,
		n.ContentText,
		n.EndDate,
		n.StartDate,
		p.Name AS PriorityName,
		s.Name AS StatusName
	FROM 
		Notes n
	JOIN 
		Priorities p ON n.PriorityId = p.Id
	JOIN 
		Statuses s ON n.StatusId = s.Id
	WHERE StatusId = @StatusId;
END
