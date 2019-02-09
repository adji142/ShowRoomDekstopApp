USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[vend2st]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[vend2st]
GO

SELECT *
INTO ISAPunyaJKT.dbo.vend2st
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM vend2st')c

GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.StockNamaImport
GO

--if exists (select i.kodebrg from ISAPunyaJKT.dbo.vend2st i OUTER APPLY (SELECT TOP 1 RowiD FROM dbo.Stock s (NOLOCK) WHERE s.KodeBarang = i.kodebrg) s where s.RowId is null)
--	insert into StockMissing
--	select i.kodebrg, 'vend2st' from ISAPunyaJKT.dbo.vend2st i OUTER APPLY (SELECT TOP 1 RowiD FROM dbo.Stock s (NOLOCK) WHERE s.KodeBarang = i.kodebrg) s where s.RowId is null

--if exists (select kd_vendor, 'vend2st'  FROM ISAPunyaJKT.dbo.vend2st i OUTER APPLY (SELECT TOP 1 RowId FROM ISPalurDb.dbo.Vendor v (NOLOCK) WHERE v.VendorID = i.kd_vendor) v where v.RowID is null)
--	insert into ISPalurDb.dbo.VendorMissing 
--	select kd_vendor, 'vend2st'  FROM ISAPunyaJKT.dbo.vend2st i
--	OUTER APPLY (SELECT TOP 1 RowId FROM ISPalurDb.dbo.Vendor v (NOLOCK) WHERE v.VendorID = i.kd_vendor) v
--	where v.RowID is null group by kd_vendor


INSERT INTO ISAPalurTradingDb02.dbo.StockNamaImport (
			RowID, StockRowID, VendorRowID, NamaImport, [Status],
			CreatedBy, CreatedOn, LastUpdatedBy, LastUpdatedDate
			)
SELECT		NEWID(),s.RowID, v.RowID, RTRIM(nm_import),0,
			'IMPORT' ,GETDATE(), 'IMPORT',GETDATE()
FROM ISAPunyaJKT.dbo.vend2st i
OUTER APPLY (SELECT TOP 1 RowiD FROM ISAPalurTradingDb02.dbo.Stock s (NOLOCK) WHERE s.KodeBarang = i.kodebrg) s
OUTER APPLY (SELECT TOP 1 RowId FROM ISPalurDb.dbo.Vendor v (NOLOCK) WHERE v.VendorID = i.kd_vendor) v

