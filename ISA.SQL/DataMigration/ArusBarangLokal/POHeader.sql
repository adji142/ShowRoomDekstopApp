USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[himport]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.himport
GO


SELECT
*
INTO ISAPunyaJKT.dbo.himport
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM himport')
GO

update ISAPunyaJKT.dbo.himport
set VTA_Beli=(CASE WHEN (VTA_Beli='NT$' OR VTA_Beli= 'TWD') then 'NTD' 
				when (VTA_Beli='RMB') then 'CNY' when (VTA_Beli='US$') then 'USD' 
				else VTA_Beli end)

DELETE FROM ISAPunyaJKT.dbo.himport WHERE idhimport=''
GO

IF EXISTS(select kd_vend FROM ISAPunyaJKT.dbo.himport po OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.Vendor v WHERE po.kd_vend=v.VendorID)v WHERE v.RowID IS NULL)
	INSERT INTO ISPalurDb.dbo.VendorMissing
	select kd_vend, 'himport' FROM ISAPunyaJKT.dbo.himport po OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.Vendor v WHERE po.kd_vend=v.VendorID)v WHERE v.RowID IS NULL GROUP BY kd_vend
GO

IF EXISTS(select vta_beli FROM ISAPunyaJKT.dbo.himport po OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.MataUang m where po.VTA_Beli=m.MataUangID)m WHERE m.RowID IS NULL)
	INSERT INTO ISPalurDb.dbo.MataUangMissing
	select vta_beli, 'himport' FROM ISAPunyaJKT.dbo.himport po OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.MataUang m where po.VTA_Beli=m.MataUangID)m WHERE m.RowID IS NULL GROUP BY vta_beli
GO


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.POHeader 
GO

INSERT INTO ISAPalurTradingDb02.dbo.POHeader
(
	RowID, 
	RecordID, 
	NoPO, 
	VendorID, 
	MataUangID, 
	TglPO, 
	TglEstimasi, 
	NamaVendor, 
	CreatedBy, CreatedOn, LastUpdatedBy, LastUpdatedDate
)
SELECT
	NEWID(),
	ltrim(rtrim(idhimport)),
	ltrim(rtrim(no_po)),
	v.RowID,
	m.RowID,
	case when year(tgl_order)<1900 then null else tgl_order end,
	case when year(estdatang)<1900 then null else estdatang end,
	ltrim(rtrim(nm_vend)),
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.himport po
OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.Vendor v WHERE po.kd_vend=v.VendorID)v
OUTER APPLY(SELECT RowID FROM ISPalurDb.dbo.MataUang m where po.VTA_Beli=m.MataUangID)m
GO  

