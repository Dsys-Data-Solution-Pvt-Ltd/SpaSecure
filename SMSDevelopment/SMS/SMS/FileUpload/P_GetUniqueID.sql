USE [Equity]
GO

/****** Object:  StoredProcedure [dbo].[P_GetUniqueId]    Script Date: 02/26/2014 10:07:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_GetUniqueId] 
	(
	@Type VARCHAR (50)
	)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT value FROM dbo.PostValues
	WHERE Type= @Type
	AND EndEffectiveDate >= GETDATE()
	OR EndEffectiveDate IS NULL
END

GO

