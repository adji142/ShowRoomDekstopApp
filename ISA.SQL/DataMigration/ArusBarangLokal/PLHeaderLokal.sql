USE ISAPunyaJKT
GO

--Htransb sudah diimport oleh PLHeader
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[HTransB]') AND type in (N'U'))
--DROP TABLE ISAPunyaJKT.dbo.HTransB
--GO


--SELECT *
--INTO ISAPunyaJKT.dbo.HTransB			
--FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM HTransB')c
--GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.PLHeaderLokal
GO



INSERT INTO ISAPalurTradingDb02.dbo.PLHeaderLokal
(
	RowId, 
	RecordID, 
	NoSJ, 
	TglSJ, 
	TglInvoice, 
	NoInvoice, 
	NoRQ, 
	TglTerima, 
	CreatedBy, 
	CreatedOn, 
	LastUpdatedBy, 
	LastUpdatedDate
)
SELECT
	NEWID() AS RowID,
	RTRIM(idtr) AS RecordID,
	RTRIM(no_sj) AS NoSJ,
	Case when YEAR(tgl_sj)<1900 then null else tgl_sj end AS TglSJ,
	Case when YEAR(tgl_nota)<1900 then null else tgl_nota end AS TglInvoice,
	no_nota AS NoInvoice,
	no_rq AS NoRQ,
	Case when YEAR(tgl_trm)<1900 then null else tgl_trm end AS TglTerima,
	'Import',
	GETDATE(),
	'Import',
	GETDATE()
FROM ISAPunyaJKT.dbo.HTransB t
GO  

 