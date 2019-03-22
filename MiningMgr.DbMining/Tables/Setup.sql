CREATE TABLE [dbo].[Setup]
(
	[Id]						INT			NOT NULL,
	[SearchModeId]				INT			NOT NULL,
	[FinderId]					INT			NOT NULL,
	[FinderAmplifierId]			INT			NOT NULL,
	[FinderDepthEnhancerQty]	TINYINT		DEFAULT 0,
	[FinderRangeEnhancerQty]	TINYINT		DEFAULT 0,
	[FinderSkillEnhancerQty]	TINYINT		DEFAULT 0,
	CONSTRAINT [IX_Setup_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Setup_Common] FOREIGN KEY ([Id]) REFERENCES [Common]([Id]),
    CONSTRAINT [FK_Setup_SearchMode] FOREIGN KEY ([SearchModeId]) REFERENCES [SearchMode]([Id]),
    CONSTRAINT [FK_Setup_Finder_Info] FOREIGN KEY ([FinderId]) REFERENCES [Finder_Info]([Id]),
    CONSTRAINT [FK_Setup_FinderAmplifier_Info] FOREIGN KEY ([Id]) REFERENCES [FinderAmplifier_Info]([Id]), 
    CONSTRAINT [CK_Setup_MaxEnhancerQty] CHECK (([FinderDepthEnhancerQty] + [FinderRangeEnhancerQty] + [FinderSkillEnhancerQty]) <= 10)
)
