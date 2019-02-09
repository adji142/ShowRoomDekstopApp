USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[stkopn]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.stkopn
GO

SELECT *
INTO ISAPunyaJKT.dbo.stkopn
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM stkopn')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.HasilOpname
GO

INSERT INTO ISAPalurTradingDb02.dbo.HasilOpname
(
	RowID, 
	StockRowID, 
	TglOpname, 
	QtyOpname, 
	Penghitung, 
	Keterangan, 
	CreatedOn, 
	CreatedBy, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	stk.RowID AS StockRowID,
	(case when year(tgl_opnm)<1900 then null else tgl_opnm end),
	qty_opnm AS QtyOpname,
	'' AS Penghitung,
	ket_opnm AS Keterangan,	
	GETDATE(),
	'Import',
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.stkopn opn
OUTER APPLY
(
	SELECT TOP 1 RowID
	FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang = opn.kode_brg
)stk
GO


 