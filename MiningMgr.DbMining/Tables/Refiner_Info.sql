-- *********************************************************
-- table `Refiner_Info`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe toutes les caractéristiques utiles des Refiners
-- *********************************************************
CREATE TABLE [dbo].[Refiner_Info]
(
	[Id]	INT				NOT NULL,
	[Eff]	DECIMAL(4,1)	NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_Refiner_Info_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Refiner_Info_Tool] FOREIGN KEY ([Id]) REFERENCES [Tool]([Id])
)
