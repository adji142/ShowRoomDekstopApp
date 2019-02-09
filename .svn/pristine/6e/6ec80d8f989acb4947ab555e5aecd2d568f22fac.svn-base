USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.His_hppa') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].His_hppa
GO
SELECT 
	*
INTO ISAPunyaJKT.dbo.His_hppa
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM His_hppa')
GO

DELETE from ISAPunyaJKT.dbo.His_hppa WHERE id_hist=''
GO

DELETE FROM ISAPalurTradingDb02.dbo.HistoryHPPA

INSERT INTO 
ISAPalurTradingDb02.dbo.HistoryHPPA
(
	RowID, 
	StockRowID, 
	HistoryID, 
	TglAktif, 
	Satuan, 
	Keterangan, 
	SyncFlag, 
	HPPAverage, 
	StockAkhir, 
	CreatedOn, 
	CreatedBy, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
NEWID(),
s.RowID,
id_hist,
(case when year(tmt)<1900 then null else Tmt end),
h.Satuan,
Keterangan,
id_match,
hpp,
qty,
GETDATE(),'Import','Import',GETDATE()
FROM ISAPunyaJKT.dbo.His_hppa h
INNER JOIN ISAPalurTradingDb02.dbo.Stock s 
ON s.idreclama=h.id_stok
GO

