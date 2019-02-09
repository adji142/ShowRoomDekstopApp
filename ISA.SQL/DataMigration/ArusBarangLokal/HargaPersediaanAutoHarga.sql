USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Histjual]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Histjual
GO

SELECT *
INTO ISAPunyaJKT.dbo.Histjual
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Histjual')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.HargaPersediaanAutoHarga
GO

INSERT INTO ISAPalurTradingDb02.dbo.HargaPersediaanAutoHarga
(
	RowID, 
	HargaPersediaanHeaderRowID, 
	StockRowID, 
	BiayaPendukung, 
	BiayaTambahan, 
	JenisIEC, 
	HargaJualUSD, 
	HargaJualIDR, 
	HargaJualNett, 
	HargaOriginal, 
	PeriodeI, 
	PeriodeII, 
	VendorRowID1, 
	Nilai1, 
	Nilai2, 
	QtyBaru, 
	MataUangRowID1, 
	HargaSatuanBaru, 
	KursUSD_ORI, 
	VendorRowID2, 
	Nilai1_2, 
	Nilai2_2, 
	QtyBaru2, 
	MataUangRowID2, 
	HargaSatuanBaru2, 
	KursUSD_ORI2, 
	VendorRowID3, 
	Nilai1_3, 
	Nilai2_3, 
	QtyBaru3, 
	MataUangRowID3, 
	HargaSatuanBaru3, 
	KursUSD_ORI3, 
	LastUpdatedBy, 
	LastUpdatedTime, 
	LastSynch, 
	Satuan, 
	Keterangan
)
SELECT 
	NEWID() AS RowID, 
	sup.RowID AS HargaPersediaanHeaderRowID, 
	stk.RowId AS StockRowID, 
	0 AS BiayaPendukung, 
	0 AS BiayaTambahan, 
	'' AS JenisIEC, 
	0 AS HargaJualUSD, 
	0 AS HargaJualIDR, 
	hjual AS HargaJualNett, 
	0 AS HargaOriginal, 
	Case when YEAR(his.tmt)<1900 then null else his.tmt end AS  PeriodeI, 
	Case when YEAR(his.tmt1)<1900 then null else his.tmt1 end AS  PeriodeII, 
	NULL AS VendorRowID1, 
	0 AS Nilai1, 
	0 AS Nilai2, 
	0 AS QtyBaru, 
	NULL AS MataUangRowID1, 
	0 AS HargaSatuanBaru, 
	0 AS KursUSD_ORI, 
	NULL AS VendorRowID2, 
	0 AS Nilai1_2, 
	0 AS Nilai2_2, 
	0 AS QtyBaru2, 
	NULL AS MataUangRowID2, 
	0 AS HargaSatuanBaru2, 
	0 AS KursUSD_ORI2, 
	NULL AS VendorRowID3, 
	0 AS Nilai1_3, 
	0 AS Nilai2_3, 
	0 AS QtyBaru3, 
	NULL AS HargaSatuanUang3, 
	0 AS HargaSatuanBaru3, 
	0 AS KursUSD_ORI3, 
	'Import' AS LastUpdatedBy, 
	GETDATE() LastUpdatedTime, 
	CASE his.id_mpric WHEN '1' THEN CONVERT(datetime,'2012/06/01') ELSE NULL END AS LastSynch, 
	his.satuan AS Satuan, 
	his.keterangan AS Keterangan
FROM ISAPunyaJKT.dbo.Histjual his
OUTER APPLY
(
	SELECT TOP 1 RowID
	FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.idreclama = his.id_stok
)stk

OUTER APPLY
(
	SELECT TOP 1 RowID
	FROM ISAPunyaJKT.dbo.Stok2Sup sup WHERE sup.id_stok = his.id_stok ORDER BY sup.tgl_qty DESC
)sup

GO