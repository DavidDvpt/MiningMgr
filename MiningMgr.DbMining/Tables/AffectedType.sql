-- *********************************************************
-- table `AffectedType`
-- Créateur : 		David MOSCA
-- Date Création : 	23/01/2019
-- Date Modif :		--/--/--
-- Description :
--		Table de liaison entre les Tools et les accessoires
--		amplis et enhancers
-- *********************************************************
CREATE TABLE [dbo].[AffectedType]
(
	[ToolTypeId] INT NOT NULL,
	[AccessoireTypeId] INT NOT NULL,
	CONSTRAINT [IX_AffectedType_Id] PRIMARY KEY([ToolTypeId], [AccessoireTypeId]), 
    CONSTRAINT [FK_AffectedType_Tool] FOREIGN KEY ([ToolTypeId]) REFERENCES [Type]([Id]),
    CONSTRAINT [FK_AffectedType_InWorld] FOREIGN KEY ([AccessoireTypeId]) REFERENCES [Type]([Id])
)
