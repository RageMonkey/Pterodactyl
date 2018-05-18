CREATE TABLE [dbo].[Processuser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProcessId] INT NOT NULL, 
    [Ptero_UserId] INT NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_dbo.Processuser_dbo.Ptero_User_Id] FOREIGN KEY ([Ptero_UserId]) REFERENCES Ptero_User ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Processuser_dbo.Process_Id] FOREIGN KEY ([ProcessId]) REFERENCES Process ([Id]) ON DELETE CASCADE
)