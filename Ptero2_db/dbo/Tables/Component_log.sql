CREATE TABLE [dbo].[Component_log]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[KeyFieldID] INT NOT NULL,
	[AuditActionTypeENUM] INT NOT NULL,
	[DateTimeStamp] DATETIME DEFAULT GETDATE() NOT NULL,
	[DataModel]    NVARCHAR(100),   
	[Changes]    NVARCHAR(MAX) NOT NULL,    
	[ValueBefore]    NVARCHAR(MAX),   
	[ValueAfter]    nvarchar(MAX),
	CONSTRAINT [FK_dbo.Component_log.KeyFieldID_Id] FOREIGN KEY ([KeyFieldID]) REFERENCES Component ([Id]) ON DELETE CASCADE,
)