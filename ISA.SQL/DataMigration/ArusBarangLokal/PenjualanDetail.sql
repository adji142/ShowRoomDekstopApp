USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dtransj]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[dtransj]
GO

SELECT *
INTO ISAPunyaJKT.dbo.dtransj
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM DTRANSJ')

delete from ISAPunyaJKT.dbo.dtransj where idrec=''

--if exists (Select dt.kode_brg FROM ISAPunyaJKT.dbo.dtransj dt outer apply(select RowID from Stock  WHERE dt.kode_brg=KodeBarang)s where s.RowId is null)
--	insert into StockMissing 
--	Select dt.kode_brg, 'dtransj' FROM ISAPunyaJKT.dbo.dtransj dt outer apply(select RowID from Stock  WHERE dt.kode_brg=KodeBarang)s where s.RowId is null


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PenjualanDetail 
GO

INSERT INTO ISAPalurTradingDb02.dbo.PenjualanDetail
(
	RowID, 
	RecordID, 
	PenjualanHeaderRowID, 
	HRecordID, 
	StockRowID, 
	KodeBarang, 
	DOBONo,
	KoliAwal,
	KoliAkhir,
	QtyRQ, 
	QtyDO, 
	QtyRealisasi, 
	QtyBO, 
	TglChecker,
	SubBPPB,
	PrintBPPB,
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	LTRIM(RTRIM(idrec)),
	h.RowID,
	LTRIM(RTRIM(idtr)),
	s.RowID,
	LTRIM(RTRIM(kode_brg)),
	no_bodo,
	0,
	0,
	j_rq,
	j_do,
	j_nota,
	j_do-j_nota,
	(case when year(tgl_save)<1900 then NULL else tgl_save end),
	sub_nota,
	nprint,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.dtransj dt
inner join ISAPalurTradingDb02.dbo.PenjualanHeader h ON dt.idtr=h.RecordID  
outer apply (select RowID from ISAPalurTradingDb02.dbo.Stock  WHERE dt.kode_brg=KodeBarang)s
GO



