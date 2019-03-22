-- *********************************************************
-- table `Finder_Info`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe toutes les caractéristiques utiles des finders
--		BasePecSearch corespond au nombre d' universal ammo dépensé
--		pour 1 recherche simple d'enmatter (O = 2E, T= 3E)
-- *********************************************************
CREATE TABLE [dbo].[Finder_Info]
(
	[Id]			INT				NOT NULL,
	[Depth]			DECIMAL (5,1)	NOT NULL	DEFAULT 0,
	[FinderRange]	Decimal(3,1)	NOT NULL	DEFAULT 0,
	[BasePecSearch]	SMALLINT		NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_Finder_Info_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Finder_Info_Tool] FOREIGN KEY ([Id]) REFERENCES [Tool]([Id])
)
