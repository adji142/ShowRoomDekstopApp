USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HMUTSTOK]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.HMUTSTOK
GO

SELECT *
INTO ISAPunyaJKT.dbo.HMUTSTOK
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM HMUTSTOK')
GO

DELETE FROM ISAPunyaJKT.dbo.HMUTSTOK WHERE id_mts=''
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.MutasiHeader
GO


INSERT INTO ISAPalurTradingDb02.dbo.MutasiHeader 
(
	RowID,
	RecordID, 
	TglMutasi, 
	NoMutasi, 
	Keterangan ,
	CreatedOn, 
	CreatedBy, 
	LastUpdatedBy, 
	LastUpdatedTime
)


SELECT		
NEWID(), 
RTRIM(id_mts),
CASE WHEN YEAR(tgl_mts)<=1900 THEN NULL ELSE tgl_mts END, 
RTRIM(no_mts), 
RTRIM(ket_mts),
GETDATE(),
'IMPORT' , 
'IMPORT',
GETDATE()
from ISAPunyaJKT.dbo.HMUTSTOK
GO