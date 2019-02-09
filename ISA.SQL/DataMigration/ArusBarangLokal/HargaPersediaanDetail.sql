
USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.HargaPersediaanDetail
GO

INSERT INTO ISAPalurTradingDb02.dbo.HargaPersediaanDetail
(
	RowID, 
	HargaPersediaanRowID, 
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
	KursUSDORI2, 
	VendorRowID3, 
	Nilai1_3, 
	Nilai2_3, 
	QtyBaru3, 
	MataUangRowID3, 
	HargaSatuanBaru3, 
	KursUSDORI3, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID, 
	hph.RowID AS HargaPersediaanRowID, 
	x.RowID AS VendorRowID1, 
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
	0 AS KursUSDORI2, 
	NULL AS VendorRowID3, 
	0 AS Nilai1_3, 
	0 AS Nilai2_3, 
	0 AS QtyBaru3, 
	NULL AS MataUangRowID3, 
	0 AS HargaSatuanBaru3, 
	0 AS KursUSDORI3, 
	'Import', 
	GETDATE()
FROM ISAPunyaJKT.dbo.Stok2Sup hph
OUTER APPLY 
(
	SELECT TOP 1
	v.RowID
	FROM
	ISPalurDb.dbo.Vendor v WHERE hph.kodesup = v.VendorID
) x



GO


 