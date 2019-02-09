USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Perusahaan]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].Perusahaan
GO

SELECT *
INTO ISAPunyaJKT.dbo.Perusahaan
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Perusahaan')c

GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.Perusahaan 
GO

INSERT INTO ISAPalurTradingDb02.dbo.Perusahaan
(
	RowID, 
	InitPerusahaan, 
	Nama, 
	Alamat, 
	Kota, 
	Propinsi, 
	Negara, 
	KodePos, 
	Telp, 
	Fax, 
	Email, 
	Website, 
	NPWP, 
	TglPKP, 
	InitCabang, 
	InitGudang, 
	TipeLokasi, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	LTRIM(RTRIM(initprs)),
	LTRIM(RTRIM(nama)),
	LTRIM(RTRIM(alamat)),
	LTRIM(RTRIM(kota)),
	LTRIM(RTRIM(propinsi)),
	LTRIM(RTRIM(negara)),
	LTRIM(RTRIM(kodepos)),
	LTRIM(RTRIM(notelp)),
	LTRIM(RTRIM(nofax)),
	LTRIM(RTRIM(email)),
	LTRIM(RTRIM(www)),
	LTRIM(RTRIM(npwp)),
	NULL,
	LTRIM(RTRIM(initcab)),
	LTRIM(RTRIM(initgdg)),
	'',
	'Import',	
	getdate()
FROM  [ISAPunyaJKT].[dbo].Perusahaan

GO
