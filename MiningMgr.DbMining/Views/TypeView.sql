CREATE VIEW [dbo].[TypeView]
AS
	SELECT Typ.Id as Id, com.Nom as Nom, com.Is_Active, cat.Is_Stackable, com2.Nom as Categorie FROM [Type] as typ
	INNER JOIN Common as com ON typ.Id = com.Id
	INNER JOIN Categorie cat ON typ.CategorieId = cat.Id
	INNER JOIN Common as com2 ON typ.CategorieId = com2.Id
