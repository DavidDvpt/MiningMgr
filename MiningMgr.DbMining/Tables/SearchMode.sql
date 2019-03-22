CREATE TABLE [dbo].[SearchMode]
(
	[Id]		INT			NOT NULL,
	[Abbrev]	VARCHAR(3)	NOT NULL,
	CONSTRAINT [IX_SearchMode_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_SearchMode_Common] FOREIGN KEY ([Id]) REFERENCES [Common]([Id])
)
