-- *********************************************************
-- table `Material`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe tous les objets utilisables en craft et 
--		trouvables dans la nature (minage, hunt, craft)
-- *********************************************************
CREATE TABLE [dbo].[Material]
(
	[Id] INT NOT NULL,
	CONSTRAINT [IX_Material_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Material_InWorld] FOREIGN KEY ([Id]) REFERENCES [InWorld]([Id])
)
