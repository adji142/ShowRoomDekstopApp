USE ISAPunyaJKT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[hbarkos]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[hbarkos]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dbarkos]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[dbarkos]
GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.hbarkos
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM hbarkos')

GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.dbarkos
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM dbarkos')

GO


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PenjualanRequestCabang 
GO


GO	
INSERT INTO ISAPalurTradingDb02.dbo.PenjualanRequestCabang
(
	RowID, 
	RecordID, 
	CabangID, 
	NoRQ, 
	TglRQ, 
	KdBarang, 
	NamaBarang, 
	QtyBO, 
	QtyPlus, 
	QtyReq, 
	QtyDO, 
	Stock00, 
	QtyJual00, 
	StockMax00, 
	Keterangan, 
	PenjualanHeaderID, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID() AS RowID,
	LTRIM(RTRIM(d.idrec)),
	LEFT(RTRIM(h.namatoko),10) AS CabangID,
	h.no_rq AS NoRQ,
	case when year(h.tgl_rq)<1900 then null else h.tgl_rq end AS TglRQ,
	d.idmain AS KdBarang,
	d.nm_plist AS NamaBarang,
	d.q_BO AS QtyBO,
	d.q_plus AS QtyPlus,
	d.qty AS QtyReq,
	null AS qtyDO,
	d.s_akhir00 AS Stock00,
	d.jual00 AS QtyJual00,
	d.st_max_00 AS StockMax00,
	d.ket AS Keterangan,
	p.RowID AS PenjualanHeaderID,
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.hbarkos h
INNER JOIN ISAPunyaJKT.dbo.dbarkos d ON h.idtr = d.idtr
OUTER APPLY
(
	SELECT TOP 1 x.RowID  FROM ISAPalurTradingDb02.dbo.PenjualanHeader x WHERE x.NoRQ = h.no_rq AND x.CabangID = h.namatoko AND x.TglRQ = h.tgl_rq
) p

GO
