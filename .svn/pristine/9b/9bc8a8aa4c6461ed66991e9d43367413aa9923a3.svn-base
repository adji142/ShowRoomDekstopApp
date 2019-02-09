USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[htransj]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[htransj]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[hbarkos]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[hbarkos]
GO


SELECT 
	*
INTO ISAPunyaJKT.dbo.htransj
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM htransj')

GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.hbarkos
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM hbarkos')

GO

if exists(select idtr from ISAPunyaJKT.dbo.htransj where idtr='')
	delete from ISAPunyaJKT.dbo.htransj where idtr=''
	
if exists(select idtr from ISAPunyaJKT.dbo.htransj where rtrim(REPLACE (idtr, char(0),'')) = '')
	delete from ISAPunyaJKT.dbo.htransj where rtrim(REPLACE (idtr, char(0),'')) = ''
	
	
	
USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PenjualanHeader 
GO	
	
INSERT INTO ISAPalurTradingDb02.dbo.PenjualanHeader
(
	RowID,
	RecordID, 
	TglRQ, 
	NoRQ, 
	TglOS, 
	NoOS, 
	NoBPPB, 
	TglBPPB, 
	DOBONo,
	Src,
	CabangID, 
	Keterangan,
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedOn
)
SELECT 
	NEWID(),
	LTRIM(RTRIM(idtr)),
	(case  when year(t.tgl_rq)< 1900 then null else t.tgl_rq end),
	LTRIM(RTRIM(t.no_rq)),
	(case  when year(b.tgl_rq)< 1900 then null else b.tgl_rq end),
	ISNULL(LTRIM(RTRIM(b.no_rq)),''),
	LTRIM(RTRIM(no_do)),
	(case  when year(tgl_do)< 1900 then null else tgl_do end),
	LTRIM(RTRIM(no_dobo)),
	'DWL' AS Src,
	LTRIM(RTRIM(Nm_toko)),
	t.ket_sj AS Keterangan,
	'Import',
	getdate(),
	'Import',	
	getdate()
FROM ISAPunyaJKT.dbo.htransj t
outer apply (select top 1 no_rq, tgl_rq from ISAPunyaJKT.dbo.hbarkos b where b.idtr=t.idtr)b

GO
