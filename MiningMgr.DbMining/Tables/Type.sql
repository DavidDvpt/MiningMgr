
-- *********************************************************
-- table `Type`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :
--		classement des items en sous catégorie
-- *********************************************************
CREATE TABLE [dbo].[Type]
(
	[Id]			INT		NOT NULL, 
    [CategorieId]	INT		NOT NULL,
	CONSTRAINT [IX_Type_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Type_Common] FOREIGN KEY (Id) REFERENCES Common(Id), 
    CONSTRAINT [FK_Type_Categorie] FOREIGN KEY (CategorieId) REFERENCES Categorie(Id)
)
