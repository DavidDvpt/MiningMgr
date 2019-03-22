-- *********************************************************
-- table `Tool`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe tous les objets principaux ayant un nombre déterminé
--		d'utilisation par minute comme les finders, excavators,
--		refiners
-- *********************************************************
CREATE TABLE [dbo].[Tool]
(
	[Id] INT NOT NULL,
	[UsePerMin] TINYINT DEFAULT NULL,
	CONSTRAINT [IX_Tool_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Tool_Unstackable] FOREIGN KEY ([Id]) REFERENCES [Unstackable]([Id])

)
