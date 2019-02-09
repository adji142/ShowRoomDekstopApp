USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dikirim]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[dikirim]
GO

SELECT 
* 
INTO ISAPunyaJKT.dbo.dikirim
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM dikirim')
GO

delete FROM ISAPunyaJKT.dbo.dikirim where id_kirim = ''
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.SJDetail 
GO
	
INSERT INTO ISAPalurTradingDb02.dbo.SJDetail
(
	RowID, 
	RecordID, 
	SjHeaderRowID, 
	PenjualanDetailRowID, 
	PenjualanDetailRecID, 
	PenjualanRowID, 
	StockRowID, 
	KodeBarang,
	NoSJ,
	j_sj,
	tgl_kirim,
	SubNoBPB, 
	KoreksiPenjualanRowID, 
	KoreksiPenjualanRecID, 
	QtyKirim, 
	NoKoli, 
	JmlKoli, 
	KoliAwal, 
	KoliAkhir, 
	HrgJual, 
	printSJ, 
	printNota, 
	printBPB, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID() AS RowID,
	ltrim(rtrim(id_kirim)) AS RecordID,
	sjh.RowID AS SJHeaderRowID,
	pd.pdRowID AS PenjualanDetailRowID,	
	ltrim(rtrim(idrec)) AS PenjualanDetailRecID,
	pd.pjRowID AS PenjualanRowID,
	stk.RowID AS StockRowID,
	sj.kode_brg AS KodeBarang,
	RTRIM(sj.no_sj) AS NoSJ,
	sj.j_sj AS j_sj,
	case when year(sj.Tgl_Kirim)<1900 then null else sj.Tgl_Kirim end AS tgl_kirim,
	id_bpb AS SubNoBPB,  
	NULL AS KoreksiPenjualanRowID,
	ltrim(rtrim(id_koreksi)) AS KoreksiPenjualanRecID,
	j_kirim AS QtyKirim,
	ISNULL(CONVERT(varchar(20),koli_awal),'') + ' - ' + ISNULL(CONVERT(varchar(20),koli_akhir),'') AS NoKoli,  -- NoKoli diisi apa?
	koli_kirim AS JmlKoli,
	koli_awal AS KoliAwal,
	koli_akhir AS KoliAkhir,
	h_jual AS HrgJual,
	id_sj AS PrintSJ,
	id_nota AS PrintNota,
	CASE ket_ctk WHEN 1 THEN 1 ELSE 0 END AS PrintBPB,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.dikirim sj
OUTER APPLY (SELECT TOP 1 * FROM ISAPalurTradingDb02.dbo.SJHeader sjx WHERE LTRIM(RTRIM(sj.No_SJ))= LTRIM(RTRIM(sjx.NoSJ))) sjh
outer apply (Select Top 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk where sj.kode_brg=stk.KodeBarang) stk
outer apply (Select Top 1 pd.RowID AS pdRowID, pj.RowID AS pjRowID  FROM ISAPalurTradingDb02.dbo.PenjualanDetail pd LEFT join ISAPalurTradingDb02.dbo.penjualanHeader pj on pd.PenjualanHeaderRowID = pj.rowid  where sj.idrec=pd.RecordID) pd
outer apply (Select TOP 1 RowID,RecordID  FROM ISAPalurTradingDb02.dbo.KoreksiPenjualan kp WHERE sj.id_koreksi = kp.SJDetailRecID) kp
GO



UPDATE dbo.PenjualanDetail 
SET
	QtyRealisasi = sj.j_sj
FROM dbo.PenjualanDetail pj
OUTER APPLY
(
	SELECT TOP 1
		sjx.j_sj
	FROM dbo.SJDetail sjx 
	WHERE
		sjx.PenjualanDetailRowID = pj.RowID
) sj

GO


INSERT INTO dbo.SJHeader
(
	RowID, 
	NoSJ, 
	Ekspedisi, 
	CabangID, 
	TglKirim, 
	NoKendaraan, 
	Sopir, 
	Berat, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID() AS RowID,
	ISNULL(LEFT( RTRIM(pj.NoBPPB),'') + ISNULL (CONVERT(varchar(20), GETDATE(), 112),15),'')  AS NoSJ,
	'' AS Ekspedisi,	
	pj.CabangID AS CabangID,
	sd.tgl_kirim AS TglKirim, 
	'' AS NoKendaraan,
	'' AS Sopir,
	'' AS Berat,
	'Import' AS CreatedBy, 
	GETDATE() AS CreatedOn, 
	'Import' AS LastUpdatedBy, 
	GETDATE() AS LastUpdatedTime
FROM dbo.SJDetail sd 
INNER JOIN dbo.PenjualanDetail pd ON sd.PenjualanDetailRowID = pd.RowID
INNER JOIN dbo.PenjualanHeader pj ON pd.PenjualanHeaderRowID = pj.RowID
WHERE
sd.NoSJ=''
GROUP BY
	pj.NoBPPB,
	pj.CabangID,
	sd.tgl_kirim	
	
	
UPDATE dbo.SJDetail
SET
	SjHeaderRowID = (SELECT TOP 1 sh.RowID FROM SJHeader sh WHERE sh.TglKirim = sd.tgl_kirim AND LEFT(sh.NoSJ,LEN(RTRIM(pj.NoBPPB ))) = RTRIM(pj.NoBPPB)  )
FROM dbo.SJDetail sd 
INNER JOIN dbo.PenjualanDetail pd ON sd.PenjualanDetailRowID = pd.RowID
INNER JOIN dbo.PenjualanHeader pj ON pd.PenjualanHeaderRowID = pj.RowID
WHERE
sd.NoSJ=''

