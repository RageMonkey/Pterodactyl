CREATE TABLE [dbo].[Component]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [desc_short] NCHAR(20) NOT NULL, 
    [desc_long] NVARCHAR(200) NOT NULL, 
    [date_created] DATETIME2 NOT NULL DEFAULT getdate()
)