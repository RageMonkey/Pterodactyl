﻿CREATE TABLE [dbo].[Role]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] INT NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE()
)