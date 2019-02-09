-- Kortrans sudah import dari KoreksiPB
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
DELETE FROM ISAPalurTradingDb02.dbo.KoreksiPBL
GO

INSERT INTO ISAPalurTradingDb02.dbo.KoreksiPBL
(
	RowID, 
	RecordID,
	PLDetailRowID, 
	StockRowID, 
	TglKoreksi, 
	NoKoreksi, 
	QtyAwal, 
	QtyAkhir, 
	HargaAwal, 
	HargaAkhir, 
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
	No_Koreksi AS NoNotaKoreksi,
	pld.QtyTerima AS QtyAwal, --QtyTerima?
	j_nota AS QtyAkhir,
	pld.HargaSatuan AS HargaAwal,
	h_jual AS HargaAkhir,
	0 AS fgKoreksiQty,
	0 AS fgKoreksiHrg,	
	GETDATE(), 
	'IMPORT',	
	GETDATE(),
	'IMPORT'	
FROM ISAPunyaJKT.dbo.Kortrans d
OUTER APPLY 
(SELECT 
TOP 1 x.RowID,QtyTerima, HargaSatuan
FROM 
ISAPalurTradingDb02.dbo.PLDetailLokal x 
INNER JOIN ISAPalurTradingDb02.dbo.Stock s ON x.BarangID = s.RowId
WHERE 
	x.KoreksiRecID = d.id_koreksi
	AND x.HRecordID = d.idtr
	AND s.KodeBarang = d.kode_brg

)pld

WHERE 
d.Sumber = 'NPB'
AND LEFT(d.kode_brg,2) <> 'FB'

GO

UPDATE PLDetailLokal
SET KoreksiID  = (SELECT TOP 1 k.RowID FROM dbo.KoreksiPBL k WHERE k.RecordID = p.KoreksiRecID AND k.StockRowID = p.BarangID )
FROM PLDetailLokal p

GO


 


 