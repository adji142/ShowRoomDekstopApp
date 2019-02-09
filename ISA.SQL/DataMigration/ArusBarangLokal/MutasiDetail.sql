USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DMUTSTOK]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DMUTSTOK
GO

SELECT *
INTO ISAPunyaJKT.dbo.DMUTSTOK			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DMUTSTOK')c
GO

DELETE FROM ISAPunyaJKT.dbo.DMUTSTOK WHERE idrec=''
GO

--IF EXISTS(SELECT idrec FROM ISAPunyaJKT.dbo.DMUTSTOK dt OUTER APPLY(SELECT  RowId FROM Stock s WHERE dt.kode_brg =s.KodeBarang)s WHERE s.RowId IS NULL)
--	INSERT INTO StockMissing
--	SELECT kode_brg,'DMutStok' FROM ISAPunyaJKT.dbo.DMUTSTOK dt OUTER APPLY(SELECT  RowId FROM Stock s WHERE dt.kode_brg =s.KodeBarang)s WHERE s.RowId IS NULL
--GO


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.MutasiDetail
GO

INSERT INTO ISAPalurTradingDb02.dbo.MutasiDetail 
(
	RowID, 
	RecordID, 
	HeaderMutasiRowID, 
	HRecordID, 
	StockRowID, 
	KodeBarang, 
	CoupleRowID, 
	Satuan, 
	QtyMutasi, 
	Keterangan, 
	CreatedOn, CreatedBy, LastUpdatedBy, LastUpdatedTime
)
SELECT		
	NEWID(), 
	d.idrec,
	h.RowID , 
	d.id_mts,
	s.RowId,
	d.kode_brg,
	NULL,	 
	d.Sat, 
	d.j_mts, 
	RTRIM(d.catatan),
	GETDATE(),'IMPORT' , 'IMPORT',GETDATE()
FROM ISAPunyaJKT.dbo.DMUTSTOK d
INNER JOIN ISAPalurTradingDb02.dbo.MutasiHeader h ON h.RecordID = d.id_mts
OUTER APPLY (SELECT Top 1 RowID FROM ISAPalurTradingDb02.dbo.Stock s Where s.KodeBarang = d.kode_brg)s
GO
