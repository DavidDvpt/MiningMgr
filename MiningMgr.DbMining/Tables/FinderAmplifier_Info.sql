-- *********************************************************
-- table `FinderAmplifier_Info`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe toutes les caractéristiques utiles des
--		finder amplifiers
-- *********************************************************
CREATE TABLE [dbo].[FinderAmplifier_Info]
(
	[Id]	INT				NOT NULL,
	[Coeff]	DECIMAL(4,1)	NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_FinderAmplifier_Info_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_FinderAmplifier_Info_Unstackable] FOREIGN KEY ([Id]) REFERENCES [Unstackable]([Id])
)
