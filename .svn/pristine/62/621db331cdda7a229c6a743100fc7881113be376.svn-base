USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dtrouble]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.dtrouble
GO

SELECT *
INTO ISAPunyaJKT.dbo.dtrouble			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM dtrouble')c
GO


USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.dbo.TokoMasalah
GO



INSERT INTO ISAPalurTradingDb02.dbo.TokoMasalah
(
  RowID, 
  Cabang1, 
  KodeToko, 
  TglAktif,
  TglPasif,
  Kategori, 
  Uraian, 
  Post, 
  Grp, 
  SyncFlag, 
  LastUpdatedBy, 
  LastUpdatedTime
)
SELECT 
	NEWID(),
	cab1,
	kd_toko,
	Case when YEAR(tmt)<1900 then null else tmt end AS tmt,
	Case when YEAR(tmt_pasif)<1900 then null else tmt_pasif end AS tmt_pasif,
	kategori,
	uraian,
	post,
	grp,
	CASE WHEN idmatch = '1' THEN 1 ELSE 0 END AS idmatch,
	'Import',
	GETDATE()		
FROM ISAPunyaJKT.dbo.dtrouble	

GO