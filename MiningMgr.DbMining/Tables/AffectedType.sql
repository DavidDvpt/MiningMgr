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
	[ToolId] INT NOT NULL,
	[InWorldId] INT NOT NULL,
	CONSTRAINT [IX_AffectedType_Id] PRIMARY KEY([ToolId], [InWorldId]), 
    CONSTRAINT [FK_AffectedType_Tool] FOREIGN KEY ([ToolId]) REFERENCES [Tool]([Id]),
    CONSTRAINT [FK_AffectedType_InWorld] FOREIGN KEY ([InWorldId]) REFERENCES [InWorld]([Id])
)
