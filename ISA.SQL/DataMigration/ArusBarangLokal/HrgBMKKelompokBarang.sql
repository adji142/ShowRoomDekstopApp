 USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.discbmk') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].discbmk
GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.discbmk
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM discbmk')
GO



DELETE FROM ISAPalurTradingDb02.dbo.HrgBmkKelompokBarang
GO


INSERT INTO ISAPalurTradingDb02.dbo.HrgBmkKelompokBarang
(
	RowID, 
	KelompokBarangRowId, 
	TglAktif, 
	HargaB, 
	HargaM, 
	HargaK, 
	HargaB2, 
	HargaM2, 
	HargaK2, 
	QtyMinB, 
	QtyMinM, 
	QtyMinK, 
	CreatedBy, 
	CreatedOn, 
	LastSynch, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID() AS RowID, 
	klp.RowId AS KelompokBarangRowId, 
	NULL AS TglAktif, 
	disc_b1 AS HargaB, 
	disc_m1 AS HargaM, 
	disc_k1 AS HargaK, 
	disc_b2 AS HargaB2,
	disc_m2 AS HargaM2,
	disc_k2 AS HargaK2,
	0 AS QtyMinB, 
	0 AS QtyMinM, 
	0 AS QtyMinK, 
	'Import', 
	GETDATE(),
	NULL AS LastSynch, 
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.discbmk dbmk
OUTER APPLY
(
	SELECT TOP 1 RowID FROM ISAPalurTradingDb02.dbo.KelompokBarang klp WHERE klp.KodeKelompokBarang = dbmk.klp
)klp
GO


 