USE ISAPunyaJKT

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dbl]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.dbl
GO

SELECT  *
INTO ISAPunyaJKT.dbo.dbl			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM dbl')c
GO


DELETE FROM ISAPalurTradingDb02.dbo.BLHeader
GO

INSERT INTO ISAPalurTradingDb02.dbo.BLHeader
(
RowID, 
PLHeaderRowID,  --??
BLID, 
TglBL, 
InvoiceNo, 
TglInvoice, 
NoContainer, 
CreatedBy, 
CreatedOn, 
LastUpdatedBy, 
LastUpdatedDate
)
SELECT
NEWID(),
NULL,
no_bl,
tgl_bl,
no_inv,
tgl_inv,
no_ctn,
'IMPORT',
GETDATE(),
'IMPORT',
GETDATE()
FROM dbo.dbl
GO