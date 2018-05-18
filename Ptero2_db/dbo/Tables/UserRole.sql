CREATE TABLE [dbo].[UserRole]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Ptero_UserId] INT NOT NULL, 
    [RoleId] INT NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [FK_dbo.UserRole.Ptero_User_Id] FOREIGN KEY ([Ptero_UserId]) REFERENCES Ptero_User ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.UserRole.Role_Id] FOREIGN KEY ([RoleId]) REFERENCES Role ([Id]) ON DELETE CASCADE
)