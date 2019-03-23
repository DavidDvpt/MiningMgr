CREATE VIEW [dbo].[SearchModeView]
AS
	SELECT sm.Id as Id, Nom, Is_Active, Abbrev FROM [SearchMode] as sm
	INNER JOIN [Common] as com ON sm.Id = com.Id
