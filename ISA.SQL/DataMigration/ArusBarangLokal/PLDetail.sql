USE ISAPunyaJKT

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HPPBeli]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.HPPBeli


GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DTransB]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DTransB
GO

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DPL]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DPL
GO




SELECT *
INTO ISAPunyaJKT.dbo.HPPBeli			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM hppbeli')c
GO


SELECT  *
INTO ISAPunyaJKT.dbo.DTransB			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DTransB where LEFT(kode_brg,2)="FB"')c
GO

SELECT  *
INTO ISAPunyaJKT.dbo.DPL
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DPL')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PLDetail
GO

INSERT INTO ISAPalurTradingDb02.dbo.PLDetail
(
	RowID, 
	RecordID, 
	HeaderID, 
	HRecordID, 
	PORowID, 
	VendorRowID, 
	StockNamaImportRowID, 
	StockRowID, 
	PODetailRowID, 
	KoreksiRecID,
	QtyPL, 
	QtyTerima, 
	OriNominal, 
	USDNominal, 
	OriMtUang, 
	USDMtUang, 
	IDRNominal, 
	IDRMtUang, 
	Komisi, 
	Disc1, 
	Disc2, 
	IDRGrossNominal, 
	CreatedBy, 
	CreatedOn, 
	LastUpdateBy, 
	LastUpdateDate
)
SELECT
	NEWID() AS RowID,
	RTRIM(idrec) AS RecordID,
	h.RowId AS HeaderID,
	RTRIM(idtr) AS HRecordID,	
	NULL AS PORowID,
	v.RowID AS VendorRowID,
	(SELECT TOP 1 imp.RowID FROM ISAPalurTradingDb02.dbo.Stock stk INNER JOIN ISAPalurTradingDb02.dbo.StockNamaImport imp ON stk.RowId = imp.StockRowID WHERE stk.KodeBarang =  d.kode_brg) AS StockNamaImportRowID,
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  d.kode_brg) AS StockRowID,
	NULL AS PODetailRowID,
	d.id_koreksi AS KoreksiRecID,
	j_sj AS QtyPL,
	j_sj AS QtyTerima,
	CASE WHEN hpp.h_nt > 0 THEN hpp.h_nt WHEN hpp.h_rmb > 0 THEN hpp.h_rmb WHEN hpp.h_us > 0 THEN hpp.h_us ELSE hpp.h_rp END  AS OriNominal,
	hpp.h_us AS USDNominal,
	(select TOP 1 RowID from ISPalurDb.dbo.MataUang WHERE MataUangID = (CASE WHEN hpp.h_nt > 0 THEN 'NTD' WHEN hpp.h_rmb > 0 THEN 'CNY' WHEN hpp.h_us > 0 THEN 'USD' ELSE 'IDR' END)) AS OriMtUang,
	0 AS USDMtUang,
	h_beli AS IDRNominal,
	0 AS IDRMtUang,
	hpp.komisi AS Komisi,
	hpp.disc1 AS Disc1,
	hpp.disc2 AS Disc2,
	hpp.h_rpnet AS IDRGrossNominal,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.DTransB d
LEFT JOIN ISAPalurTradingDb02.dbo.PLHeader h ON d.idtr=h.RecordID
LEFT JOIN ISAPunyaJKT.dbo.HppBeli hpp ON d.idrec = hpp.id_dosheet
OUTER APPLY (SELECT Top 1 RowID FROM  ISPalurDb.dbo.Vendor Where LTRIM(RTRIM(VendorID)) = LTRIM(RTRIM (d.Pemasok)))v

/*
UPDATE ISAPalurTradingDb02.dbo.PlDetail
SET
VendorRowID = v.RowID
FROM 
ISAPalurTradingDb02.dbo.pldetail d
inner join ISAPunyaJKT.dbo.htransb h on d.hrecordid = h.idtr
inner join ISPalurDb.dbo.Vendor v on ltrim(rtrim(h.id_vendor)) =ltrim(rtrim( v.idreclama))
*/

UPDATE dbo.PLDetail
SET
	PORowID = po.HeaderID,
	PODetailRowID = po.RowID
FROM dbo.PLDetail dt
INNER JOIN ISAPunyaJKT.dbo.dpl dp ON dt.RecordID = dp.iddpl
INNER JOIN dbo.PODetail po ON dp.idrec = po.RecordID


UPDATE dbo.PLDetail
SET
	PORowID = poh.RowID,
	PODetailRowID = pod.RowID
FROM dbo.PLDetail d
INNER JOIN dbo.PLHeader h ON d.HeaderID = h.RowId
INNER JOIN dbo.Stock s ON d.StockRowID = s.RowId
INNER JOIN ISAPunyaJKT.dbo.DPL p ON RTRIM(h.PLID) = RTRIM(p.no_pl) AND s.KodeBarang = p.kode_brg
INNER JOIN dbo.POHeader poh ON p.idtr = poh.RecordID
INNER JOIN dbo.PODetail pod ON p.idrec = pod.RecordID
WHERE
d.PODetailRowID IS NULL

DELETE FROM ISAPalurTradingDb02.dbo.PLDetail
WHERE HeaderID IS NULL

DELETE FROM ISAPalurTradingDb02.dbo.PLHeader
WHERE RowID NOT IN (SELECT HeaderID FROM ISAPalurTradingDb02.dbo.PLDetail)



GO  

 