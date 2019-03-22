-- *********************************************************
-- table `FinderAmplifier_Info`
-- Créateur : 		David MOSCA
-- Date Création : 	22/03/2019
-- Date Modif :		--/--/--
-- Description :
--		Regroupe toutes les caractéristiques utiles des
--		finder amplifiers
-- *********************************************************
CREATE TABLE [dbo].[Enhancer_Info]
(
	[Id]			INT				NOT NULL,
	[Slot]			TINYINT			NOT NULL,
	[BonusValue1]	DECIMAL(4,2)	NOT NULL	DEFAULT 0,
	[BonusValue2]	DECIMAL(4,2)	NOT NULL	DEFAULT 0,
	CONSTRAINT [IX_Enhancer_Info_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Enhancer_Info_InWorld] FOREIGN KEY ([Id]) REFERENCES [InWorld]([Id])
)
