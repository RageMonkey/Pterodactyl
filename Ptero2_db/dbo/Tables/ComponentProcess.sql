CREATE TABLE [dbo].[ComponentProcess]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ComponentId] INT NOT NULL, 
    [ProcessId] INT NOT NULL,	
    [date_created] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_dbo.ComponentProcess.Component_Id] FOREIGN KEY ([ComponentId]) REFERENCES Component ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ComponentProcess.ProcessType_Id] FOREIGN KEY ([ProcessId]) REFERENCES Process ([Id]) ON DELETE CASCADE
)