USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DIMPORT]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DIMPORT
GO

SELECT *
INTO ISAPunyaJKT.dbo.DIMPORT
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DIMPORT')c
GO

DELETE FROM ISAPunyaJKT.dbo.DIMPORT WHERE iddtransb=''
GO

IF EXISTS(select kd_brgdg from ISAPunyaJKT.dbo.DIMPORT c OUTER APPLY (SELECT TOP 1 ROWID 
			 FROM ISAPalurTradingDb02.dbo.Stock s(NOLOCK) WHERE s.KodeBarang =c.kd_brgdg)s where s.RowId IS NULL)
	INSERT INTO ISAPalurTradingDb02.dbo.StockMissing
	select kd_brgdg, 'DImport' from ISAPunyaJKT.dbo.DIMPORT c OUTER APPLY (SELECT TOP 1 ROWID 
			 FROM ISAPalurTradingDb02.dbo.Stock s(NOLOCK) WHERE s.KodeBarang =c.kd_brgdg)s where s.RowId IS NULL GROUP BY kd_brgdg
GO

USE ISAPalurTradingDb02
GO
DELETE FROM  ISAPalurTradingDb02.dbo.PODetail
GO

INSERT INTO ISAPalurTradingDb02.dbo.PODetail 
(
	RowID, 
	RecordID, 
	HeaderID, 
	HRecordID, 
	BarangID, 
	StockNamaImportID, 
	QtyPO, 
	HrgSatuanPO, 
	HrgSatuanPOUSD, 
	CreatedBy, CreatedOn, LastUpdatedBy, LastUpdatedDate
)
SELECT		
	NEWID(), 
	RTRIM(iddtransb),
	h.RowID, 
	RTRIM(idhTransb),	
	s.RowId, 
	i.RowID,
	qpo, 
	hsat_po,
	rate_beli,
	'IMPORT', GETDATE(), 'IMPORT', GETDATE()
FROM ISAPunyaJKT.dbo.DIMPORT c
INNER JOIN ISAPalurTradingDb02.dbo.POHeader h ON h.RecordID = c.idhTransb
OUTER APPLY (SELECT TOP 1 ROWID 
			 FROM ISAPalurTradingDb02.dbo.Stock s(NOLOCK) WHERE s.KodeBarang =c.kd_brgdg)s
OUTER APPLY (
			SELECT TOP 1 RowId
			FROM ISAPalurTradingDb02.dbo.StockNamaImport i WHERE i.StockRowID = s.RowId
			)i
			


