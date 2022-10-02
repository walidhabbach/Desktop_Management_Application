USE [DataBaseMagasin]
GO

INSERT INTO [dbo].[COMMANDEFOUR]
           ([IDFOUR]
           ,[DESCRIPTION]
           ,[STATUT]
           ,[DATECMD]
           ,[PESPECE]
           ,[PCHEQUE]
           ,[MONTANTTOTAL]
           ,[MTRESTE]
           ,[MTAVANCE])
     VALUES
           (1,'10 lawt',0,2022-08-20,0,1,2400,NULL,NUll),
		   (2,'5 Brokard',0,2022-08-21,0,1,30000,NULL,NUll),
		   (3,'2 Matelas',0,2022-08-21,0,1,2000,NULL,NUll),
		   (4,'2 Brokard gris',0,2022-08-21,0,1,12000,NULL,NUll)
GO


