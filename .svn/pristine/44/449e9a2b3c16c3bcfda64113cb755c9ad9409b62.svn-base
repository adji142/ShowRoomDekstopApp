USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HSJalan]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[HSJalan]
GO


SELECT 
	*
INTO ISAPunyaJKT.dbo.HSJalan
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM HSJalan')

GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.SJHeader 
GO

INSERT INTO ISAPalurTradingDb02.dbo.SJHeader
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
	NEWID(),
	LTRIM(RTRIM(no_sj)),
	LTRIM(RTRIM([Exp])),
	LTRIM(RTRIM(c00)),
	(case when year(tanggal)<1900 then null else tanggal end),
	LTRIM(RTRIM(nocar)),
	LTRIM(RTRIM(driver)),
	berat,
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.HSJalan

GO
 