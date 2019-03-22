-- *********************************************************
-- table `Unstackable`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe tous les objets non empilables qui possedent une variable usure
--		comme les finders, excavators, refiners et finder ampifiers
-- *********************************************************
CREATE TABLE [dbo].[Unstackable]
(
	[Id]		INT				NOT NULL,
	[IsLimited]	BIT				NOT NULL	DEFAULT 0,
	[Decay]		DECIMAL(7,3)	NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_Unstackable_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Unstackable_InWorld] FOREIGN KEY ([Id]) REFERENCES [InWorld]([Id])
)
