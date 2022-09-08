INSERT INTO [dbo].[CHEF]
           ([LOGIN]
           ,[CODE])
     VALUES ('walid','2002');
GO

/*==============================================================*/
/* fOURnisseur                                     */
/*==============================================================*/
INSERT INTO [dbo].[FOURNISSEUR]
           ([ENTREPRISE]
           ,[TELEPHONE]
           ,[CATEGORIE]
           ,[ADRESSE])
     VALUES
           ('Richbond','0528838739','Matelas','Agadir'),
		   ('Dehbi','0500000001','Tissus','Agadir'),
		   ('Paris Dor','0500000002','Matelas','Agadir'),
		   ('Zmama','0500000003','Tissus','casa');
		  
GO

INSERT INTO [dbo].[PRODUIT]
           ([IDPRODUIT]
           ,[IDFOUR]
           ,[DESIGNATION]
           ,[PRIXACHAT]
           ,[PRIXVENTE]
           ,[DPRIXVENTE])
     VALUES
            ('BL�810' ,1 ,'lawat' ,240 ,300,280),
			('BL�811' ,1 ,'lawat' ,240 ,300,280),
            ('N�812' ,3 ,'matelas' ,1000,1350,1250),
			('812-712' ,4 ,'tissus' ,1000,1350,1250),
            ('#121',2,'BROKARD GRIS COUS',120,170,150),
			('#122',2,'ROKARD VERT COUSS',120,170,150),
			('#120',2,'BROKARD BEIGE RAYER',120,170,150);
               
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
           (1,'10 lawt',0,'2022-08-20',0,1,2400,NULL,NUll),
		   (2,'5 Brokard',0,'2022-08-21',0,1,30000,NULL,NUll),
		   (3,'2 Matelas',0,'2022-08-21',0,1,2000,NULL,NUll),
		   (4,'2 Brokard gris',0,'2022-08-21',0,1,12000,NULL,NUll)
GO

INSERT INTO [dbo].[COMMANDER]
           ([IDPRODUIT]
           ,[ID_CMD_FOUR]
           ,[QUANTITE])
     VALUES
           ('BL°810',1,5),
		  ('BL°811',1,5),
		   ('#122',2,2),
		   ('#120',2,1),
		   ('#121',2,2),
		   ('N°811',3,2),
		   ('812-712',4,2)
		   
GO


INSERT INTO [dbo].[CHEQUEFOURNISSEUR]
           ([DATEDONNER]
           ,[DATEPAYER]
           ,[MONTANT])
     VALUES
           ('2022-08-21','2022-09-21',30000),
           ('2022-08-20','2022-10-21',30000,00)
           ('2022-08-22','2022-11-21',30000,00)

GO

INSERT INTO [dbo].[REGLE_CHQ_FOUR]
           ([IDCHQ_FOUR]
           ,[ID_CMD_FOUR])
     VALUES
		(1,2),
		(2,1),
		(3,3)

GO
/*==============================================================*/
/*    CLient                                                    */
/*==============================================================*/


INSERT INTO [dbo].[CLIENT]
           ([NOM]
           ,[TELEPHONE])
     VALUES
           ('CLT1','060000001'),
		   ('CLT2','060000002'),
		   ('CLT3','060000003'),
		   ('CLT4','060000004')
GO

INSERT INTO [dbo].[COMMANDECLIENT]
           ([IDCLIENT]
           ,[DESIGNATION]
           ,[DATE_DEBUT]
           ,[DATE_LIMITE]
           ,[STATUT]
           ,[MONTANTTOTAL]
           ,[MTAVANCE]
           ,[MTRESTE]
           ,[PCHEQUE]
           ,[PESPECE])
     VALUES
               (1,'Salon','2022-08-11','2022-08-24',0,6000,500,5500,0,1),
		   (2,'SalonL','2022-08-9','2022-08-22',0,6000,500,5500,0,1),
		   (3,'Salon','2022-08-15','2022-08-28',0,6000,500,5500,0,1),
		   (4,'Salon','2022-08-20','2022-08-26',0,6000,500,5500,0,1)
GO

INSERT INTO [dbo].[PAIEMENTESPECECLT]
           ([DATE_PAIEMENT]
           ,[MONTANT])
     VALUES
           ('2022-08-11',500),
		   ('2022-08-24',5500),
		   ('2022-08-09',500),
		   ('2022-08-15',500),
		   ('2022-08-20',500),
		   ('2022-08-22',5500)
GO

INSERT INTO [dbo].[REGLERESPECE]
           ([IDESPECE_CLT]
           ,[ID_CMD_CLT]
           ,[IDCLIENT])
     VALUES
           (1,1,1),
		   (2,1,1),
		   (3,2,2),
		   (4,3,3),
		   (5,4,4),
		   (6,2,2)
GO