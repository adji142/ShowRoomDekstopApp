 USE ISAPunyaJKT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[DTransB]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.DTransB
GO

SELECT  *
INTO ISAPunyaJKT.dbo.DTransB			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM DTransB where LEFT(kode_brg,2)<>"FB"')c
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PLDetailLokal
GO


INSERT INTO ISAPalurTradingDb02.dbo.PLDetailLokal
(
	RowID, 
	HeaderID, 
	PORowID, 
	VendorRowID, 
	PODetailRowID, 
	RecordID, 
	HRecordID, 
	BarangID, 
	KoreksiRecID,
	KoreksiID, 
	QtySJ, 
	QtyTerima, 
	Ppn, 
	Diskon, 
	HargaSatuan, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedDate
)
SELECT
	NEWID() AS RowID,
	h.RowId AS HeaderID,
	NULL AS PORowID,
	v.RowID AS VendorRowID, -- HOW ??
	NULL AS PODetailRowID,
	
	RTRIM(idrec) AS RecordID,	
	RTRIM(idtr) AS HRecordID,
	(SELECT TOP 1 stk.RowID FROM ISAPalurTradingDb02.dbo.Stock stk WHERE stk.KodeBarang =  d.kode_brg) AS BarangID,
	d.id_koreksi AS KoreksiRecID,
	NULL AS KoreksiID,
	j_sj AS QtySJ,
	j_sj AS QtyTerima,
	ppn AS Ppn,
	disc_1 AS Diskon, -- HOW ??
	h_beli AS HargaSatuan,	-- HOW ??
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.DTransB d
LEFT JOIN ISAPalurTradingDb02.dbo.PLHeaderLokal h ON d.idtr=h.RecordID
OUTER APPLY (SELECT Top 1 RowID FROM  ISPalurDb.dbo.Vendor Where LTRIM(RTRIM(VendorID)) = LTRIM(RTRIM (d.Pemasok)))v


UPDATE dbo.PLDetailLokal
SET
	PORowID = po.HeaderID,
	PODetailRowID = po.RowID
FROM dbo.PLDetailLokal dt
INNER JOIN ISAPunyaJKT.dbo.dpl dp ON dt.RecordID = dp.iddpl
INNER JOIN dbo.PODetail po ON dp.idrec = po.RecordID

UPDATE dbo.PLDetailLokal
SET
	PORowID = NULL,
	PODetailRowID = NULL
FROM dbo.PLDetailLokal d



--UPDATE dbo.PLDetailLokal
--SET
--	PORowID = poh.RowID,
--	PODetailRowID = pod.RowID
--FROM dbo.PLDetailLokal d
--INNER JOIN dbo.PLHeaderLokal h ON d.HeaderID = h.RowId
--INNER JOIN dbo.Stock s ON d.BarangID = s.RowId
--INNER JOIN ISAPunyaJKT.dbo.DPL p ON RTRIM(h.NoSJ) = RTRIM(p.no_pl) AND s.KodeBarang = p.kode_brg
--INNER JOIN dbo.POHeaderLokal poh ON p.idtr = poh.RecordID
--INNER JOIN dbo.PODetailLokal pod ON p.idrec = pod.RecordID
--WHERE
--d.PODetailRowID IS NULL


DELETE FROM ISAPalurTradingDb02.dbo.PLHeaderLokal 
WHERE RowID NOT IN (SELECT HeaderID FROM dbo.PLDetailLokal)


DELETE FROM ISAPalurTradingDb02.dbo.PLDetailLokal
WHERE HeaderID IS NULL
GO  

  