USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[ststoko]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.ststoko
GO

SELECT *
INTO ISAPunyaJKT.dbo.ststoko			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM ststoko')c
GO


USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.dbo.TokoStatus
GO



INSERT INTO ISAPalurTradingDb02.dbo.TokoStatus
(
	RowID, 
	TokoID, 
	CabangID, 
	TglAktif, 
	Status, 
	RecordID, 
	Keterangan, 
	SyncFlag, 
	KStatus, 
	Roda, 
	TglPasif, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	t.RowID AS TokoID,
	c1 AS CabangID,
	Case when YEAR(tmt)<1900 then null else tmt end AS TglAktif,
	sts AS [Status],
	idrec AS RecordID,
	ket AS Keterangan,
	id_match AS SyncFlag,
	ksts AS KStatus,
	rd AS Roda,
	Case when YEAR(tmt_pasif)<1900 then null else tmt_pasif end AS TglPasif,	
	'Import',
	GETDATE()		
FROM ISAPunyaJKT.dbo.ststoko sts
OUTER APPLY
(
	SELECT x.RowID FROM ISAPalurTradingDb02.dbo.Toko x WHERE x.KodeToko = sts.kd_toko
) t	

GO 