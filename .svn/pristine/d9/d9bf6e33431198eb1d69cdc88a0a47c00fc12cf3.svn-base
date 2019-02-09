USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[hstoksales]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[hstoksales]
GO

SELECT *
INTO ISAPunyaJKT.dbo.hstoksales
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM hstoksales')c



USE ISAPalurTradingDb02
GO
DELETE FROM dbo.StockSalesHeader
GO

INSERT INTO dbo.StockSalesHeader
(
	RowID, 
	RecordID, 
	Kelompok, 
	CreatedBy, 
	CreatedDate, 
	LastUpdatedBy, 
	LastUpdatedDate
)
SELECT 	
	NEWID() AS RowID, 
	LEFT(dbo.fnCreateFingerPrint('IMP'),19) + LEFT(CONVERT(varchar(50),NEWID()),3) AS RecordID,
	Kelompok, 	
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.hstoksales
GROUP BY Kelompok

GO
