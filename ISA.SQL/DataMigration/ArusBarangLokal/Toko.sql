USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[MTOKO]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.MTOKO
GO

SELECT *
INTO ISAPunyaJKT.dbo.MTOKO			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM MTOKO')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.Toko 
GO

INSERT INTO ISAPalurTradingDb02.dbo.Toko
(
	RowID, 
	TokoID, 
	NamaToko, 
	Alamat, 
	Kota, 
	Telp, 
	PenanggungJawab, 
	KodeToko, 
	PiutangB, 
	PiutangJ, 
	Plafon, 
	ToJual, 
	ToRetPot, 
	JangkaWaktuKredit, 
	Cabang2, 
	Tgl1st, 
	Exist, 
	ClassID, 
	Catatan, 
	SyncFlag, 
	HariKirim, 
	KodePos, 
	Grade, 
	Plafon1st, 
	Flag, 
	Bentrok, 
	StatusAktif, 
	HariSales, 
	Daerah, 
	Propinsi, 
	AlamatRumah, 
	Pengelola, 
	TglLahir, 
	HP, 
	Status, 
	ThnBerdiri, 
	StatusRuko, 
	JmlCabang, 
	JmlSales, 
	Kinerja, 
	BidangUsaha, 
	RefSales, 
	RefCollector, 
	RefSupervisor, 
	PlafonSurvey, 
	No_Toko, 
	Exp_Norm, 
	Cabang, 
	Cabang1, 
	I_Spart, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	idtoko AS TokoID,
	namatoko AS NamaToko,
	alamat AS Alamat,
	kota AS Kota,
	notelp AS Telp, 
	pngjwb AS PenanggungJawab, 
	kd_toko AS KodeToko,
	piutang_b AS PiutangB,
	piutang_j AS PiutangJ,
	plafon AS Plafon,
	to_jual AS ToJual,
	to_retpot AS ToRetPot,
	jkw_kredit AS JangkaWaktuKredit,
	cab2 AS Cabang2, 
	tgl1st AS Tgl1st,
	exist AS Exist,	
	idclass AS ClassID,
	catatan AS catatan,	
	CASE WHEN id_match = 'T' THEN 1 ELSE 0 END AS SyncFlag,
	hari_krm AS HariKirim,
	'' AS KodePos,
	grade AS Grade,
	plafon_1st ASPlafon1st ,
	flag AS Flag,
	bentrok AS Bentrok ,
	lpasif AS StatusAktif,
	hari_sls AS HariSales,
	daerah AS Daerah,
	propinsi AS Propinsi,
	alm_rumah AS AlamatRumah,
	pengelola AS Pengelola,
	tgl_lahir AS TglLahir,
	handphone AS HP,
	[status] AS [Status],
	th_berdiri AS ThnBerdiri,
	lruko AS StatusRuko,
	jml_cabang AS JmlCabang,
	jml_sales AS JmlSales,
	kinerja AS Kinerja,
	bdg_usaha AS BidangUsaha,
	reff_sls AS RefSales,
	reff_col AS RefCollector,
	reff_spv AS RefSupervisor,
	plf_survey AS PlafonSurvey,	
	no_toko AS No_Toko,
	exp_norm AS Exp_Norm,
	cab AS Cabang,
	cab1 AS Cabang1,
	j_spart AS I_Spart,
	'Import',
	GETDATE()	
FROM ISAPunyaJKT.dbo.MToko

GO


 