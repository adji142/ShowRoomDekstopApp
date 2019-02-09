-- Kortrans sudah import dari KoreksiPB
--USE ISAPunyaJKT
--GO
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Kortrans]') AND type in (N'U'))
--DROP TABLE ISAPunyaJKT.dbo.Kortrans
--GO

--SELECT *
--INTO ISAPunyaJKT.dbo.Kortrans			
--FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Kortrans')c
--GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.KoreksiRBLokal
GO

/*
INSERT INTO dbo.KoreksiRBLokal
(
	RowID, 
	RBDetailRowID, 
	TglKoreksi, 
	NoKoreksi, 
	QtyAwal, 
	QtyAkhir, 
	HargaAwal, 
	HargaAkhir, 
	StockRowID, 
	FgKoreksiQty, 
	FgKoreksiHrg, 
	FgCetakNota, 
	CreatedOn, 
	CreatedBy, 
	LastUpdatedTime, 
	LastUpdatedBy
)
SELECT		
	NEWID() AS RowID, 
	drb.RowID AS RBDetailRowID,
	Case when YEAR(TglKoreksi)<1900 then null else TglKoreksi end AS TglKoreksi,
	No_Koreksi AS NoNotaKoreksi,
	0 AS QtyAwal,
	j_sj AS QtyAkhir,
	0 AS HargaAwal,
	h_Koreksi AS HargaAkhir,
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  d.kode_brg) AS StockRowID,	
	1 AS fgKoreksiQty,
	0 AS fgKoreksiHrg,	
	0 AS fgCetakNota,
	GETDATE(), 
	'IMPORT',	
	GETDATE(),
	'IMPORT'	
FROM ISAPunyaJKT.dbo.Kortrans d
OUTER APPLY 
(SELECT TOP 1 x.RowID FROM ISAPunyaJKT.dbo.DReturB x WHERE x.idrec = d.id_detail)drb
WHERE 
d.Sumber = 'NRB'
AND LEFT(d.kode_brg,2) <> 'FB'

GO


 
*/

 