USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HReturJ]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.HReturJ
GO

SELECT 
*
INTO ISAPunyaJKT.dbo.HReturJ
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM HReturJ')
GO

delete from ISAPunyaJKT.dbo.HReturJ where idretur=''
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.RJHeader 
GO

INSERT INTO ISAPalurTradingDb02.dbo.RJHeader
(
	RowID, 
	RecordID, 
	TglMPR, 
	NoMPR, 
	NoRetur, 
	TglKeluarCabang, 
	TglGudang, 
	CabangPemintaID, 
	CabangPenerimaID, 
	LinkID, 
	NPrint, 
	LastSynch, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	LTRIM(RTRIM(idretur)) AS RecordID,
	(CASE WHEN YEAR(tgl_ret)<1900 THEN NULL ELSE tgl_ret END) AS TglMPR,
	LTRIM(RTRIM(no_seri)) AS NoMPR,
	LTRIM(RTRIM(no_ret)) AS NoRetur,
	(CASE WHEN YEAR(tgl_ntjd)<1900 THEN NULL ELSE tgl_ntjd END) AS TglKeluarCabang,
	(CASE WHEN YEAR(tgl_gudang)<1900 THEN NULL ELSE tgl_gudang END) AS TglGudang,
	LTRIM(RTRIM(nm_toko)) AS CabangPemintaID,
	LTRIM(RTRIM(nm_toko2)) AS CabangPenerimaID,
	(SELECT TOP 1 RowID FROM ISAPalurTradingDb02.dbo.PenjualanHeader pj WHERE pj.RecordID = rt.idretur) AS LinkID,
	[Print] AS NPrint,
	GETDATE(),
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.HReturJ rt

GO
