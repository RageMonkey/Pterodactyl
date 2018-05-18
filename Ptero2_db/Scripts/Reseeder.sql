DELETE  FROM Ptero2_db.dbo.Ptero_User
DBCC CHECKIDENT('Ptero2_db.dbo.Ptero_User',RESEED,0)
DBCC CHECKIDENT('Ptero2_db.dbo.Ptero_User')
DBCC CHECKIDENT('Ptero2_db.dbo.Process',RESEED,0)
DBCC CHECKIDENT('Ptero2_db.dbo.Process')
DBCC CHECKIDENT('Ptero2_db.dbo.Component',RESEED,0)
DBCC CHECKIDENT('Ptero2_db.dbo.Component')