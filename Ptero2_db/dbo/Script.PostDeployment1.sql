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
