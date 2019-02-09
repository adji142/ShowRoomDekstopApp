--STAGING TABLE
USE ISAPunyaJKT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Dsalesin]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].Dsalesin
GO
SELECT 
	*
INTO ISAPunyaJKT.dbo.Dsalesin
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM Dsalesin')
GO

--END STAGING TABLE

DELETE FROM ISAPalurTradingDb02.dbo.AccHargaDetail
GO

INSERT INTO 
ISAPalurTradingDb02.dbo.AccHargaDetail

(
	RowID, 
	AccHargaRowID, 
	KdBarang, 
	NamaBarangCabang, 
	HrgDO, 
	HrgAcc,
	HrgPokok,
	HrgBMK, 
	Diskon1, 
	Diskon2, 
	Diskon3, 
	Potongan, 
	QtyDO, 
	QtyAcc, 
	StatusAcc, 
	AlasanPenolakan, 
	NamaPenolak, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime, 
	RecordID, 
	HRecordID, 
	NoAcc, 
	SyncFlag
)
SELECT
	NEWID() AS RowID,
	(SELECT TOP 1 RowID FROM ISAPalurTradingDb02.dbo.AccHargaHeader acc WHERE acc.RecordID = idtr) AS AccHargaRowID,
	kode_brg AS KdBarang,
	nama_stok AS NamaBarangCabang,		
	rp_dojual AS HrgDO,
	rp_accjual AS HrgAcc,
	h_pokok AS HrgPokok,
	h_bmk AS HrgBMK,
	disc_1 AS Diskon1,
	disc_2 AS Diskon2,
	disc_3 AS Diskon3,
	pot_rp AS Potongan,
	j_do AS QtyDO,
	j_acc AS QtyAcc,
	CASE WHEN RTRIM(no_acc) <> '' AND j_acc > 0 THEN 'A' WHEN RTRIM(no_acc) = '' AND j_acc = 0 THEN 'T' ELSE '' END AS StatusAcc,
	alas_tolak AS AlasanPenolakan,
	'' AS NamaPenolak,	
	'Import' AS CreatedBy,
	GETDATE() AS CreatedOn,
	'Import' AS LastUpdatedBy,
	GETDATE() AS LastUpdatedOn,
	idrec AS RecordID,
	idtr AS HRecordID,
	no_acc AS NoAcc,
	id_match AS Syncflag
FROM ISAPunyaJKT.dbo.Dsalesin




GO

