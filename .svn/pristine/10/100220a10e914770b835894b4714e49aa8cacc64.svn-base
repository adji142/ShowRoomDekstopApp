USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[kortransRJ]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.kortransRJ
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.KoreksiRJ
GO


SELECT 
* INTO ISAPunyaJKT.dbo.kortransRJ
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM kortrans WHERE TRIM(Sumber)="NRJ"')
GO






INSERT INTO ISAPalurTradingDb02.dbo.KoreksiRJ
(
	RowID, 
	RecordID, 
	RJDetailRowID, 
	RJDetailRecID, 
	TglKoreksi, 
	NoKoreksi, 
	HrgAwal,
	QtyAwal,
	HrgKoreksi, 
	QtyKoreksi, 
	FgKoreksiHrg, 
	FgKoreksiQty, 
	FgCetakNota, 
	CreatedBy, CreatedOn, LastUpdatedBy, LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	LTRIM(RTRIM(kr.id_koreksi)) AS RecordID,
	rj.RowID AS RJDetailRowID,
	LTRIM(RTRIM(r.idrec)) AS RJDetailRecID,
	LTRIM(RTRIM(kr.tglkoreksi)) AS TglKoreksi,
	LTRIM(RTRIM(kr.no_koreksi)) AS NoKoreksi,
	rj.HrgJual AS HrgAwal,
	rj.QtyPengakuan AS QtyAwal,
	kr.h_jual AS HrgKoreksi,
	kr.j_sj AS QtyKoreksi,	
	0 AS FgKoreksiHrg,
	0 AS FgKoreksiQty,
	0 AS FgCetakNota,
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.kortransRJ kr
INNER JOIN ISAPunyaJKT.dbo.DReturJ r on r.id_koreksi=kr.id_koreksi
INNER JOIN ISAPalurTradingDb02.dbo.RJDetail rj on rj.RecordID = r.idrec
GO
 