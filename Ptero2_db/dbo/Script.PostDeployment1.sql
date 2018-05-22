/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DELETE FROM Ptero2_db.dbo.Component
DELETE FROM Ptero2_db.dbo.Ptero_User
DELETE FROM Ptero2_db.dbo.Process
DELETE FROM Ptero2_db.dbo.Phase
DELETE FROM Ptero2_db.dbo.Role
/*DROP TABLE Ptero2_db.dbo.AspNetUserLogins
DROP TABLE Ptero2_db.dbo.AspNetUsers */
/*DELETE FROM Ptero2_db.dbo.AspNetUserRoles
DELETE FROM Ptero2_db.dbo.AspNetUserClaims */
/*DELETE FROM Ptero2_db.dbo.AspNetRoles */

DBCC CHECKIDENT('Ptero2_db.dbo.Ptero_User',RESEED,0)
/*DBCC CHECKIDENT('Ptero2_db.dbo.Ptero_User') */
DBCC CHECKIDENT('Ptero2_db.dbo.PROCESS',RESEED,0)
/* DBCC CHECKIDENT('Ptero2_db.dbo.Process')  */
DBCC CHECKIDENT('Ptero2_db.dbo.Component',RESEED,0)
/* DBCC CHECKIDENT('Ptero2_db.dbo.Component') */
DBCC CHECKIDENT('Ptero2_db.dbo.Phase',RESEED,0)
DBCC CHECKIDENT('Ptero2_db.dbo.Role',RESEED,0)

MERGE INTO Ptero2_db.dbo.Component AS Target 
USING (VALUES 
        (1,'Automton','Replace benefits processing with robots','2018-04-06'), 
        (2,'BrainFt2', 'Generate life from cadavers using electricity','2018-05-12'), 
        (3,'1MnthOld', 'Replace all people with robots','2018-04-01'),
        (4,'6MnthOld', 'Replace all robots with rabbits','2018-02-01'),
        (5,'2yearOld', 'Replace all rabbits with poets','2016-05-01')
) 
AS Source (Id,desc_short, desc_long, date_created) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (desc_short, desc_long, date_created) 
VALUES (desc_short, desc_long, date_created);
GO


MERGE INTO Ptero2_db.dbo.Ptero_User AS Target
USING (VALUES 
        (1,'Tibbetts', 'Donnie', 'tibbetts@gmail.com'), 
        (2,'Guzman', 'Liza', 'guzoman@gandg.com') ,
        (3,'Ferguson', 'Felix', 'felix@ptero.com') 
)
AS Source (Id, last_name, first_name, user_email)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (last_name, first_name, user_email)
VALUES (last_name, first_name, user_email);
GO
DELETE FROM Ptero2_db.dbo.Process

MERGE INTO Ptero2_db.dbo.Process AS Target
USING (VALUES 
(1,'Identify'),
(2,'Categorise'),
(3,'Evaluate'),
(4,'Select'),
(5,'Risk management'),
(6,'Prioritise')
)
AS Source (Id,Description)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Description)
VALUES (Description);
GO

MERGE INTO Ptero2_db.dbo.Processuser AS Target
USING (VALUES 
(1,3,1,'2018-03-01'),
(2,6,1,'2018-03-11'),
(3,4,2,'2018-03-31'),
(4,2,3,'2018-03-06'),
(5,1,3,'2018-02-01')
)
AS Source (Id,ProcessId,Ptero_UserId,date_created)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (ProcessId,Ptero_UserId,date_created)
VALUES (ProcessId,Ptero_UserId,date_created);
GO

MERGE INTO Ptero2_db.dbo.ComponentProcess AS Target
USING (VALUES 
(1,1,3,'2018-03-11'),
(2,2,5,'2018-03-12'),
(3,3,1,'2018-04-01')
)
AS Source (Id,ComponentId,ProcessId,date_created)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (ComponentId,ProcessId,date_created)
VALUES (ComponentId,ProcessId,date_created);
GO

/* Phases */
MERGE INTO Ptero2_db.dbo.Phase AS Target
USING (VALUES 
(1,'Starting','2018-03-11'),
(2,'Mulling Over','2018-03-12'),
(3,'Finishing','2018-04-01')
)
AS Source (Id,Description,date_created)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Description,date_created)
VALUES (Description,date_created);
GO


/* Roles */
MERGE INTO Ptero2_db.dbo.Role AS Target
USING (VALUES 
(1,'Administrator','2018-03-19'),
(2,'Project Manager','2017-12-12'),
(3,'Gumby','2018-01-01')
)
AS Source (Id,Description,date_created)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Description,date_created)
VALUES (Description,date_created);
GO


/* Component Users */
MERGE INTO Ptero2_db.dbo.ComponentUser AS Target
USING (VALUES 
(1,1,3,'2018-03-19'),
(2,4,1,'2017-12-12'),
(3,5,2,'2018-01-01')
)
AS Source (Id,ComponentId,Ptero_UserId,date_created)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (ComponentId,Ptero_UserId,date_created)
VALUES (ComponentId,Ptero_UserId,date_created);
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);


GO
ALTER TABLE [dbo].[AspNetUsers]
    ADD CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC);

	CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;

	CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


	CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);


GO
ALTER TABLE [dbo].[AspNetRoles]
    ADD CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC);


CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;




