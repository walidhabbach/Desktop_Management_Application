USE [DataBaseMagasin]
GO

INSERT INTO [dbo].[PRODUIT]
           ([IDPRODUIT]
           ,[IDFOUR]
           ,[DESIGNATION]
           ,[PRIXACHAT]
           ,[PRIXVENTE]
           ,[DPRIXVENTE])
     VALUES
            ('N°810' ,3 ,'lawat' ,600 ,900,750),
            ('N°812' ,3 ,'matelas' ,1000,1350,1250),
            ('BROKARD GRIS COUS',2,'BROKAR',120,170,150),
			('BROKARD VERT COUSS',2,'BROKAR',120,170,150),
			('BROKARD BEIGE RAYER',2,'BROKAR',120,170,150);
               
GO


