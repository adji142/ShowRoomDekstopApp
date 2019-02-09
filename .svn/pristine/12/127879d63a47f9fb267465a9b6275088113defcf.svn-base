USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Kortrans]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Kortrans
GO

SELECT *
INTO ISAPunyaJKT.dbo.Kortrans			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Kortrans')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.KoreksiPB
GO

DECLARE @idr uniqueidentifier
SET @idr = (select TOP 1 RowID from ISPalurDb.dbo.MataUang WHERE MataUangID = 'IDR')

INSERT INTO ISAPalurTradingDb02.dbo.KoreksiPB
(
	RowID, 
	RecordID,
	PLDetailRowID, 
	StockRowID, 
	TglKoreksi, 
	NoKoreksi, 
	QtyAwal, 
	QtyAkhir, 
	OriAwal, 
	OriAkhir, 
	USDAwal, 
	USDAkhir, 
	IDRAwal, 
	HrgKoreksi, 
	fgKoreksiQty, 
	fgKoreksiHrg, 
	CreatedOn, 
	CreatedBy, 
	LastUpdatedTime, 
	LastUpdatedBy
)
SELECT		
	NEWID() AS RowID, 
	d.id_koreksi,
	pld.RowID AS PLDetailRowID,
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  d.kode_brg) AS StockRowID,
	Case when YEAR(TglKoreksi)<1900 then null else TglKoreksi end AS TglKoreksi,
	No_Koreksi AS NoKoreksi,
	ISNULL(pld.QtyTerima,0) AS QtyAwal, -- Qty.Terima ?
	j_nota AS QtyAkhir,
	0 AS OriAwal,
	0 AS OriAkhir,
	0 AS USDAwal,
	0 AS USDAkhir,
	ISNULL(pld.IDRNominal,0) AS IDRAwal,
	ISNULL(h_jual ,0) HrgKoreksi,
	0 AS fgKoreksiQty,
	0 AS fgKoreksiHrg,	
	GETDATE(), 
	'IMPORT',	
	GETDATE(),
	'IMPORT'	
FROM ISAPunyaJKT.dbo.Kortrans d
OUTER APPLY 
(SELECT 
TOP 1 x.RowID,QtyTerima,IDRNominal 
FROM 
 ISAPalurTradingDb02.dbo.PLDetail x
INNER JOIN ISAPalurTradingDb02.dbo.Stock s ON x.StockRowID = s.RowId
WHERE 
	x.KoreksiRecID = d.id_koreksi
	AND s.KodeBarang = d.kode_brg

)pld
WHERE 
d.Sumber = 'NPB'
AND LEFT(d.kode_brg,2) = 'FB'

GO

