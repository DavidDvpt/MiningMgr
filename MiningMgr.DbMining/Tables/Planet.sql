-- *********************************************************
-- table `Planet`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :
--		planetes utiles à la localisation de certains
--		minerais et/ou outils
-- *********************************************************
CREATE TABLE [dbo].[Planet]
(
	[Id]	INT		NOT NULL,
	CONSTRAINT [IX_Planet_Id] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Planet_Common] FOREIGN KEY (Id) REFERENCES Common(Id)
)
