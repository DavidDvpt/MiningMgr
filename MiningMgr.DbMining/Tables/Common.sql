-- *****************************************************************************
-- table `Common`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :	
--		Table contenant les informations communes à toutes les entités utilisés
--		par l'application
-- *****************************************************************************
CREATE TABLE [dbo].[Common]
(
	[Id]			INT			NOT NULL	IDENTITY(1,1), 
    [Nom]			NCHAR(50)	NOT NULL, 
    [Is_Active]		BIT			NOT NULL	DEFAULT 1,
	CONSTRAINT [IX_Common_Id] PRIMARY KEY([Id])
)
