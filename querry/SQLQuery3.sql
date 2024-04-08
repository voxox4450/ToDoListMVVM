SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetNotes
	
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
		Statuses s ON n.StatusId = s.Id;
END
GO
