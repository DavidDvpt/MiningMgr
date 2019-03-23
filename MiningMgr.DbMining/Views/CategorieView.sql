CREATE VIEW [dbo].[CategorieView]
AS
	SELECT cat.Id as Id, Nom, Is_Active FROM [Categorie] as cat
	INNER JOIN [Common] as com ON cat.Id = com.Id
