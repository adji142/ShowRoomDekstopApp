USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[metode]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].metode
GO


SELECT
	*
INTO ISAPunyaJKT.dbo.metode
FROM openquery(mysql04,'select * from palurbase.dmetode')



USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.DBO.BiayaPerSupplier

INSERT INTO ISAPalurTradingDb02.DBO.BiayaPerSupplier
(
	RowId, 
	Tanggal, 
	VendorID, 
	ByPenerimaan, 
	ByPenyimpanan, 
	ByKomisi, 
	Nilai1, 
	Nilai2, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID() AS RowID, 
	tanggal AS  Tanggal, 
	kd_vendor, 
	by_terima AS ByPenerimaan, 
	by_simpan AS ByPenyimpanan,
	by_komisi AS ByKomisi,
	Per_1 AS Nilai1, 
	Per_2 AS Nilai2, 
	'Import', 
	GETDATE()
FROM ISAPunyaJKT.dbo.metode mtd

UPDATE dbo.BiayaPerSupplier
SET 
VendorRowID = x.RowID
FROM dbo.BiayaPerSupplier b
OUTER APPLY

(
	SELECT TOP 1
		RowID
	FROM ISPalurDb.dbo.Vendor v WHERE b.VendorID = v.VendorID
)x



GO