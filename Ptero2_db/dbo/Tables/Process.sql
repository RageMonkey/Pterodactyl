﻿CREATE TABLE [dbo].[Process]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NCHAR(30) NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE()
)