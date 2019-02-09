USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Stok2Sup]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Stok2Sup
GO

SELECT NEWID() AS RowID, *
INTO ISAPunyaJKT.dbo.Stok2Sup
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Stok2Sup')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.HargaPersediaanHeader
GO



INSERT INTO ISAPalurTradingDb02.dbo.HargaPersediaanHeader
(
	RowID, 
	StockRowID, 
	BiayaPendukung, 
	BiayaTambahan, 
	JenisIEC, 
	HargaJualUSD, 
	HargaJualIDR, 
	HargaJualNett, 
	HargaOriginal, 
	QtyStockGudang, 
	TglStockGudang, 
	CreatedOn, 
	CreatedBy, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	hph.RowID, 
	stk.RowID AS StockRowID, 
	hph.kardus AS BiayaPendukung, 
	hph.bea_1 AS BiayaTambahan, 
	hph.ie AS JenisIEC, 
	0 AS HargaJualUSD, 
	0 AS HargaJualIDR, 
	hph.hjual_net AS HargaJualNett, 
	hph.op AS HargaOriginal, 
	hph.qty AS QtyStockGudang, 
	Case when YEAR(hph.tgl_qty)<1900 then null else hph.tgl_qty end AS  TglStockGudang, 
	GETDATE(), 
	'Import', 
	'Import',
	GETDATE() 
	
FROM ISAPunyaJKT.dbo.Stok2Sup hph
OUTER APPLY
(
	SELECT TOP 1 RowID
	FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.idreclama = hph.id_stok
)stk
GO


 