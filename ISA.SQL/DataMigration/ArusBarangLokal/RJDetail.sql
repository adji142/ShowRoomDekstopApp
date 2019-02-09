USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DReturJ]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DReturJ
GO

SELECT *
INTO ISAPunyaJKT.dbo.DReturJ
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM DRETURJ')
GO

delete from ISAPunyaJKT.dbo.DReturJ where idrec=''
GO

--IF EXISTS(SELECT idrec FROM ISAPunyaJKT.dbo.DReturJ dt OUTER APPLY(SELECT  RowId FROM ISAPalurTradingDb02.dbo.Stock s WHERE dt.kode_brg =s.KodeBarang)s WHERE s.RowId IS NULL)
--	INSERT INTO ISAPalurTradingDb02.dbo.StockMissing
--	SELECT kode_brg,'DReturJ' FROM ISAPunyaJKT.dbo.DReturJ dt OUTER APPLY(SELECT  RowId FROM ISAPalurTradingDb02.dbo.Stock s WHERE dt.kode_brg =s.KodeBarang)s WHERE s.RowId IS NULL
--GO

DELETE FROM ISAPalurTradingDb02.dbo.RJDetail 
GO

INSERT INTO ISAPalurTradingDb02.dbo.RJDetail
(
	RowID, 
	RecordID, 
	RJHeaderRowID, 
	HRecordID, 
	PenjualanDetailRowID,
	PenjualanDetailRecID,
	StockRowID, 
	KodeBarang, 
	QtyRetur, 
	QtyPengakuan, 
	HrgJual,
	AsalNota,
	Kategori,
	Detail, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	LTRIM(RTRIM(idrec)),
	h.RowID,
	LTRIM(RTRIM(idretur)),
	pd.RowID,
	LTRIM(RTRIM(iddtr)),
	s.RowId,
	LTRIM(RTRIM(kode_brg)),
	q_terima,
	q_gudang,
	h_jual,
	LTRIM(RTRIM(asalnota)),
	LTRIM(RTRIM(kategori)),
	LTRIM(RTRIM(detail)),
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.DReturJ dt
INNER JOIN ISAPalurTradingDb02.dbo.RJHeader h
ON dt.idretur=h.RecordID
OUTER APPLY(SELECT  RowId FROM ISAPalurTradingDb02.dbo.Stock s WHERE dt.kode_brg =s.KodeBarang)s
OUTER APPLY(SELECT RowID FROM  ISAPalurTradingDb02.dbo.PenjualanDetail pd WHERE LEFT(dt.iddtr,21) = LEFT(pd.RecordID,21))pd
GO

--UPDATE ISAPalurTradingDb02.DBO.RJDetail
--SET RJHeaderRowID = a.RowID
--FROM ISAPalurTradingDb02.DBO.RJHeader a INNER JOIN
--ISAPalurTradingDb02.DBO.RJDetail b ON a.RecordID = b.HRecordID
--GO

UPDATE ISAPalurTradingDb02.dbo.RJDetail
SET
	PenjualanDetailRowID = x.RowID
FROM ISAPalurTradingDb02.dbo.RJDetail dt
OUTER APPLY
(
	SELECT RowID FROM  ISAPalurTradingDb02.dbo.PenjualanDetail pd WHERE LEFT(dt.PenjualanDetailRecID,19) = LEFT(pd.RecordID,19)
) X
WHERE
	PenjualanDetailRowID IS NULL
	AND LEN(PenjualanDetailRecID) <=21
	AND RTRIM(PenjualanDetailRecID) <> ''
GO
