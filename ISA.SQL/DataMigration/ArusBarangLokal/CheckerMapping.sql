 USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dgudang]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.dgudang
GO

SELECT *
INTO ISAPunyaJKT.dbo.dgudang
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM dgudang')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.CheckerMapping
GO

INSERT INTO ISAPalurTradingDb02.dbo.CheckerMapping
(
	RowID, 
	PenjualanDetailRowID, 
	idrec, 
	nama1, 
	nama2, 
	nama3, 
	idgudang1KaryawanRowID, 
	idgudang2KaryawanRowID, 
	idgudang3KaryawanRowID
)
SELECT 
	NEWID() AS RowID,
	pj.RowID AS PenjualanDetailRowID,
	idrec,
	nama1,
	nama2,
	nama3,
	NULL,
	NULL,
	NULL
FROM ISAPunyaJKT.dbo.dgudang dgd
OUTER APPLY
(
	SELECT TOP 1 RowID
	FROM ISAPalurTradingDb02.dbo.PenjualanDetail pj WHERE pj.RecordID = dgd.idrec
)pj
--OUTER APPLY
--(
--	SELECT TOP 1 RowID
--	FROM ISAPalurdb.dbo.Karyawan ky WHERE ky.RecordID = dgd.idgudang1

--)ky1
--OUTER APPLY
--(
--	SELECT TOP 1 RowID
--	FROM ISAPalurdb.dbo.Karyawan ky WHERE ky.RecordID = dgd.idgudang2

--)ky2
--OUTER APPLY
--(
--	SELECT TOP 1 RowID
--	FROM ISAPalurdb.dbo.Karyawan ky WHERE ky.RecordID = dgd.idgudang3

--)ky3
GO


 