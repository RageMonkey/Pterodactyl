CREATE TABLE [dbo].[Ptero_User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [first_name] NCHAR(30) NOT NULL, 
    [last_name] NCHAR(30) NOT NULL, 
    [user_email] NCHAR(50) NOT NULL,
	[date_created] DATETIME2 NOT NULL DEFAULT GETDATE()
)