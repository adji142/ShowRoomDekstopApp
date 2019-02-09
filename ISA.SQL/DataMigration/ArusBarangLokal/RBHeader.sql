USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HReturB]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.HReturB
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.RBHeader
GO

SELECT NewID() AS RowID, *
INTO ISAPunyaJKT.dbo.HReturB			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM HReturB')c
GO

DELETE FROM ISAPunyaJKT.dbo.HReturB WHERE idretur=''
GO
delete FROM ISAPunyaJKT.dbo.HreturB where REPLACE(left(idretur,1),char(0),'')=''
GO


INSERT INTO ISAPalurTradingDb02.dbo.RBHeader 
(
	RowID, 
	RecordID, 
	NoRetur, 
	TglRetur, 
	VendorRowID, 
	SJRowID, 
	Pengirim, 
	TglReturDiTerima,  
	CreatedOn, CreatedBy, LastUpdatedBy, LastUpdatedTime
)
SELECT		
	d.RowID, 
	d.idretur,
	rtrim(d.No_retur),
	(CASE WHEN YEAR(d.tgl_retur)<1900 THEN NULL ELSE d.tgl_retur END),
	v.RowID,
	s.RowID,
	rtrim(d.pengirim),
	(CASE WHEN YEAR(d.tgl_keluar)<1900 THEN NULL ELSE d.tgl_keluar END), -- BLUM PASTI!
	GETDATE(),'IMPORT' , 'IMPORT',GETDATE()
FROM ISAPunyaJKT.dbo.HReturB d
OUTER APPLY (SELECT Top 1 RowID FROM ISAPalurTradingDb02.dbo.PLHeader p Where p.PLID = d.no_sj and d.no_sj<>'')s
OUTER APPLY (SELECT Top 1 RowID FROM  ISPalurDb.dbo.Vendor Where VendorID = d.Pemasok)v
GO
 