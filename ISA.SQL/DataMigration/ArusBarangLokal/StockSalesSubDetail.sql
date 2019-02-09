USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dstoksales]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[dstoksales]
GO

SELECT *
INTO ISAPunyaJKT.dbo.dstoksales
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM dstoksales')c


USE ISAPalurTradingDb02
GO
DELETE FROM dbo.StockSalesSubDetail
GO

INSERT INTO dbo.StockSalesSubDetail
(
	RowID, 
	HeaderRowID, 
	RecordID, 
	HRecordID, 
	StockRowID, 
	NamaBarang, 
	PartNo, 
	Kendaraan, 
	Type, 
	Satuan, 
	Statuspasif, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedOn
)
SELECT 	
	NEWID() AS RowID, 
	d.RowID AS HeaderRowID, 
	idrec AS RecordID, 
	idtr AS HRecordID, 
	s.RowId AS StockRowID, 
	x.namastok AS NamaBarang, 
	x.PartNo AS PartNo, 
	x.Kendaraan AS Kendaraan, 
	x.[Type] AS Type,
	x.satuan AS Satuan, 
	x.lpasif AS Statuspasif, 
	'Import', 
	GETDATE(), 
	'Import', 
	GETDATE()
FROM ISAPunyaJKT.dbo.dstoksales x
LEFT JOIN dbo.StockSalesDetail d ON d.RecordID = x.idtr
LEFT JOIN dbo.Stock s ON x.idrecstok = s.IDRecLama
GO
