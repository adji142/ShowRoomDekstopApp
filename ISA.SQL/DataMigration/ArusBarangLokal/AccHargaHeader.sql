--STAGING TABLE
USE ISAPunyaJKT
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Hsalesin]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].Hsalesin
GO
SELECT 
	*
INTO ISAPunyaJKT.dbo.Hsalesin
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ',
 'SELECT 	idtr,
	wilayah,
	png_jwb,
	DTOC(tgl_req) AS tgl_req,
	kd_cust,
	no_do,
	DTOC(tgl_do) AS tgl_do,
	kd_sales,
	no_acc,
	DTOC(tgl_acc) AS tgl_acc,
	DTOC(tgl_upl) AS tgl_upl,
	flag1 FROM Hsalesin')
GO

--END STAGING TABLE



DELETE FROM ISAPalurTradingDb02.dbo.AccHargaHeader

GO

INSERT INTO ISAPalurTradingDb02.dbo.AccHargaHeader
SELECT
	NEWID() AS RowID,
	idtr AS RecordID,
	LEFT(wilayah,2) AS CabangRequestorID,
	'' AS CabangPengirim,
	png_jwb AS Requestor,
	CAST((CASE WHEN tgl_req = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_req,4) < 1900 THEN NULL
					  ELSE tgl_req 
					  END) AS DATETIME) AS TglRQ,	
	(SELECT TOP 1 t.RowID FROM ISAPalurTradingDb02.dbo.Toko t WHERE t.KodeToko = kd_cust) AS TokoRowID,
	kd_cust AS KodeTokoLama,
	no_do AS NoDO,
	CAST((CASE WHEN tgl_do = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_do,4) < 1900 THEN NULL
					  ELSE tgl_do 
					  END) AS DATETIME) AS TglDO,			
	kd_sales AS KdSales,
	CAST((CASE WHEN tgl_acc = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_acc,4) < 1900 THEN NULL
					  ELSE tgl_acc 
					  END) AS DATETIME) AS TglAcc,		
	no_acc AS NoACC,			
	NULL AS PenanggungJwbRowID,
	CAST((CASE WHEN tgl_upl = '  /  /  ' THEN NULL
					   WHEN RIGHT(tgl_upl,4) < 1900 THEN NULL
					  ELSE tgl_upl 
					  END) AS DATETIME) AS TglUpload,	
	flag1 AS SyncFlag,
	'Import' AS CreatedBy,
	GETDATE() AS CreatedOn,
	'Import' AS LastUpdatedBy,
	GETDATE() AS LastUpdatedTime
FROM ISAPunyaJKT.dbo.Hsalesin
--DELETE FROM ISAPalurTradingDb02.dbo.AccHargaHeader






GO

