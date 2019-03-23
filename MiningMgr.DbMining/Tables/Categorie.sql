-- *********************************************************
-- table `Categorie`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :
--		Classification de tous les types d'item avec
--		precision sur la possibilité d'empilage des items
-- *********************************************************
CREATE TABLE [dbo].[Categorie]
(
	[Id]			INT		NOT NULL, 
    [Is_Stackable]	BIT		NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_Categorie_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Categorie_Common] FOREIGN KEY ([Id]) REFERENCES [Common]([Id])
)
