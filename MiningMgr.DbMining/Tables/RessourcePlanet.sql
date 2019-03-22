-- *********************************************************
-- table `RessourcePlanet`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :
--		Table de liaison entre les planetes et les ressources
--		Indique ou chaque ressource peut être trouvé
-- *********************************************************
CREATE TABLE [dbo].[RessourcePlanet]
(
	[MaterialId] INT NOT NULL,
	[PlanetId] INT NOT NULL,
	CONSTRAINT [IX_RessourcePlanet_Id] PRIMARY KEY([MaterialId], [PlanetId]), 
    CONSTRAINT [FK_RessourcePlanet_Material] FOREIGN KEY ([MaterialId]) REFERENCES [Material]([Id]),
    CONSTRAINT [FK_RessourcePlanet_Planet] FOREIGN KEY ([PlanetId]) REFERENCES [Planet]([Id])
)
