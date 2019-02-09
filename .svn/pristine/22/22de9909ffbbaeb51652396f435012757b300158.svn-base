 USE ISAPalurTradingDb02
GO
DELETE FROM dbo.StockSalesDetail
GO

INSERT INTO dbo.StockSalesDetail
(
	RowID, 
	HeaderRowID, 
	RecordID, 
	HRecordID, 
	GroupBarang, 
	CreatedBy, 
	CreatedDate, 
	LastUpdatedBy, 
	LastUpdatedDate
)
SELECT 	
	NEWID() AS RowID, 
	h.RowID AS HeaderRowID, 
	d.idtr AS RecordID, 
	h.RecordID AS HRecordID, 
	LEFT(d.namagroup,50) AS GroupBarang,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.hstoksales d
LEFT JOIN dbo.StockSalesHeader h ON h.Kelompok = d.kelompok


GO
 