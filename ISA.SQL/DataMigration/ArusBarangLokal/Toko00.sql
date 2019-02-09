USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Toko00_Import]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Toko00_Import
GO

SELECT 
NEWID() AS RowID,
NEWID() AS TokoID,
RTRIM(idtoko) AS IDToko,
RTRIM(kd_toko) AS KodeToko,
RTRIM(cab1) AS Cabang,
RTRIM(idwil) AS WilID,
RTRIM(no_urut) AS NoUrut,  
tgl_edit AS TglEdit,
RTRIM(idrec_post) AS RecordIDPost,   
RTRIM(l_edit) AS LEdit,
RTRIM(catatan) AS Catatan,
'Import' AS CreatedBy,
GETDATE() AS CreatedOn,
'Import' AS LastUpdatedBy,
GETDATE() AS LastUpdatedTime
INTO ISAPunyaJKT.dbo.Toko00_Import
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM TOKO00')
GO

DELETE FROM ISAPalurTradingDb02.DBO.Toko00
GO




UPDATE ISAPunyaJKT.dbo.Toko00_Import
SET TokoID = b.RowID
FROM ISAPunyaJKT.dbo.Toko00_Import a INNER JOIN ISAPalurTradingDb02.DBO.Toko b ON a.IDToko = b.TokoID
GO


INSERT INTO ISAPalurTradingDb02.DBO.Toko00
(
RowID, 
TokoID, 
KodeToko, 
Cabang,
WilID, 
NoUrut, 
TglEdit, 
RecordIDPost, 
LEdit, 
Catatan, 
CreatedBy, 
CreatedOn, 
LastUpdatedBy, 
LastUpdatedTime
)
SELECT 
	RowID, 
	TokoID, 
	KodeToko, 
	Cabang,
	WilID, 
	NoUrut, 
	TglEdit, 
	RecordIDPost, 
	LEdit, 
	Catatan, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
FROM ISAPunyaJKT.dbo.Toko00_Import

	
