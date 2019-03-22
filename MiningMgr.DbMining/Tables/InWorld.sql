-- *********************************************************
-- table `InWorld`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe tous les objets trouvables dans le jeu
-- *********************************************************
CREATE TABLE [dbo].[InWorld]
(
	[Id]			INT		NOT NULL,
	[TypeId]		INT		NOT NULL,
	[IsStackable]	BIT		NOT NULL	DEFAULT 0,
	[Value]	DECIMAL(9,5)	NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_InWorld_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_InWorld_Common] FOREIGN KEY ([Id]) REFERENCES [Common]([Id]), 
    CONSTRAINT [FK_InWorld_Type] FOREIGN KEY ([TypeId]) REFERENCES [Type]([Id])
)
