USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[kortransPJ]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.kortransPJ
GO

SELECT 
* INTO ISAPunyaJKT.dbo.kortransPJ
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM kortrans WHERE TRIM(Sumber)="NPJ"')
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.KoreksiPenjualan 
GO

INSERT INTO ISAPalurTradingDb02.dbo.KoreksiPenjualan
(
	RowID, 
	RecordID, 
	SJDetailRowID, 
	SJDetailRecID, 
	TglKoreksi, 
	NoKoreksi,
	TglKomplain,
	NoKomplain,
	StockRowID,
	HrgAwal,
	QtyAwal,
	HrgKoreksi, 
	QtyKoreksi, 
	FgKoreksiHarga, 
	FgKoreksiQty, 
	FgCetakNota, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	LTRIM(RTRIM(id_koreksi)) AS RecordID,
	sj.RowID AS SJDetailRowID,
	sj.RecordID AS SJDetailRecID,
	LTRIM(RTRIM(tglkoreksi)) AS TglKoreksi,
	RTRIM(no_koreksi) AS NoKoreksi,
	tglkompl AS TglKomplain,
	nokompl AS NoKomplain,
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  kp.kode_brg) AS StockRowID,
	sj.HrgJual AS HrgAwal,
	sj.QtyKirim AS QtyAwal,	
	h_jual AS HrgKoreksi,
	(kp.j_sj) AS QtyKoreksi,		
	0 AS FgKoreksiHarga,
	0 AS FgKoreksiQty,
	0 AS FgCetakNota,
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.kortransPJ kp
--INNER JOIN ISAPalurTradingDb02.dbo.SJDetail sj ON kp.id_koreksi=sj.KoreksiPenjualanRecID
OUTER APPLY
	(
	SELECT TOP 1 RowID, RecordID, HrgJual, QtyKirim
	FROM ISAPalurTradingDb02.dbo.SJDetail x 
	WHERE kp.id_koreksi=x.KoreksiPenjualanRecID
	)sj
GO

--UPDATE SJDETAIL.KOREKSIPENJUALANROWID
Update ISAPalurTradingDb02.dbo.SJDetail
Set KoreksiPenjualanRowID=kp.RowID
FROM ISAPalurTradingDb02.dbo.SJDetail s INNER JOIN ISAPalurTradingDb02.dbo.KoreksiPenjualan kp ON kp.SJDetailRowID=s.RowID
GO 

