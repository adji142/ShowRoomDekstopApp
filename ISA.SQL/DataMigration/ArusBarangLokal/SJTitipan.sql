 USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Titip]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[Titip]
GO

SELECT 
* 
INTO ISAPunyaJKT.dbo.Titip
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM Titip')

GO



USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.SJTitipan
GO
	
INSERT INTO ISAPalurTradingDb02.dbo.SJTitipan
(
	RowID, 
	SJHeaderRowID, 
	Keterangan, 
	Qty, 
	Satuan
)
SELECT
	NEWID() AS RowID,
	sjh.RowID AS SJHeaderRowID,
	ket AS Keterangan,
	jumlah AS Qty,
	'' AS Satuan
FROM ISAPunyaJKT.dbo.Titip ttp
INNER JOIN ISAPalurTradingDb02.dbo.SJHeader sjh ON ttp.No_SJ=sjh.NoSJ
GO