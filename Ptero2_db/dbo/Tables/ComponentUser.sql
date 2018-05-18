CREATE TABLE [dbo].[ComponentUser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ComponentId] INT NOT NULL , 
    [Ptero_UserId] INT NOT NULL,   
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_dbo.ComponentUser_dbo.Component_Id] FOREIGN KEY ([ComponentId]) REFERENCES Component ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ComponentUser_dbo.Ptero_User_Id] FOREIGN KEY ([Ptero_UserId]) REFERENCES Ptero_User ([Id]) ON DELETE CASCADE
)