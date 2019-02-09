 USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DReturB]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DReturB
GO

SELECT NEWID() AS RowID, *
INTO ISAPunyaJKT.dbo.DReturB			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DReturB  where LEFT(kode_brg,2)<>"FB"')c
GO

DELETE FROM ISAPunyaJKT.dbo.DReturB WHERE idretur=''
GO
delete FROM ISAPunyaJKT.dbo.DreturB where REPLACE(left(idretur,1),char(0),'')=''
GO


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.RBDetailLokal
GO

DECLARE @idr uniqueidentifier
SET @idr = (select TOP 1 RowID from ISPalurDb.dbo.MataUang WHERE MataUangID = 'IDR')

INSERT INTO ISAPalurTradingDb02.dbo.RBDetailLokal
(
	RowID, 
	HeaderID, 
	PLLokalDetailRowID, 
	StockRowID, 
	QtyRetur, 
	Alasan,
	HrgReturBeli, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT		
	d.RowID AS RowID, 
	h.RowID AS RBHeaderID,
	(SELECT TOP 1 RowID FROM ISAPalurTradingDb02.dbo.PLDetailLokal pld WHERE pld.RecordID = d.iddtr ) AS PLLokalDetailRowID,	
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  d.kode_brg) AS StockRowID,
	Q_gudang AS QtyRetur, --OR Q_Terima?
	'' AS Alasan,
	h_beli AS HrgReturBeli, 
	'IMPORT',
	GETDATE(), 
	'IMPORT',
	GETDATE()
FROM ISAPunyaJKT.dbo.DReturB d
OUTER APPLY (SELECT Top 1 RowID FROM ISAPalurTradingDb02.dbo.RBHeader h Where h.RecordID = d.idretur)h

GO
 


 