CREATE TABLE [dbo].[PhaseProcess]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PhaseId] INT NOT NULL, 
    [ProcessId] INT NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_dbo.Phase_dbo.Phase_Id] FOREIGN KEY ([PhaseId]) REFERENCES Phase ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Phase_dbo.Process_Id] FOREIGN KEY ([ProcessId]) REFERENCES Process ([Id]) ON DELETE CASCADE
)