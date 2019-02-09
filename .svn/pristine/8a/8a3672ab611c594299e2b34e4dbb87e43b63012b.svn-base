USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HTransB]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.HTransB
GO

SELECT NEWID() AS RowID, *
INTO ISAPunyaJKT.dbo.HTransB			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM HTransB')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PLHeader 
GO


INSERT INTO ISAPalurTradingDb02.dbo.PLHeader
(
	RowId, 
	RecordID, 
	PLID, 
	NoRQ, 
	TglPL, 
	TglTerima, 
	Forwarder, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedDate
)
SELECT
	NEWID() AS RowID,
	RTRIM(idtr) AS RecordID,
	RTRIM(no_sj) AS PLID,
	RTRIM(no_rq) AS NoRQ,	
	Case when YEAR(tgl_sj)<1900 then null else tgl_sj end AS TglPL,
	Case when YEAR(tgl_trm)<1900 then null else tgl_trm end AS TglTerima,
	'' AS Forwarder,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()	
FROM ISAPunyaJKT.dbo.HTransB t
GO  

 