USE [DataBaseMagasin]
GO

DECLARE @RC int
DECLARE @iDFour int

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[CHEQUE_FOURNISSEUR] 
   @iDFour=1
GO


