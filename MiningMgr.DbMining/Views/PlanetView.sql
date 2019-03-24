CREATE VIEW [dbo].[PlanetView]
AS
	SELECT p.Id as Id, Nom, Is_Active FROM [Planet] as p
	INNER JOIN [Common] as com ON p.Id = com.Id
GO

--CREATE UNIQUE CLUSTERED INDEX idx_PlanetView_Id
--	ON PlanetView (Id)
--GO
