CREATE VIEW [dbo].[CategorieView]
AS
	SELECT cat.Id as Id, Nom, Is_Active FROM [Categorie] as cat
	INNER JOIN [Common] as com ON cat.Id = com.Id
GO
--CREATE UNIQUE CLUSTERED INDEX idx_CatView_Id
--	ON CategorieView (Id)
--GO