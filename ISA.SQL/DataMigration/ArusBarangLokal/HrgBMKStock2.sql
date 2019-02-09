/* Author : Anung Satriaji Rahman
   Created Date	: 29 Mei 2012
*/

USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.price_c') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].price_c
GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.price_c
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM price_c')
GO



DELETE FROM ISAPalurTradingDb02.dbo.HrgBmkStock2
GO


INSERT INTO ISAPalurTradingDb02.dbo.HrgBmkStock2
(
RowID, 
RecordID, 
StockRowID, 
StockRecordID, 
TglAktif, 
HrgPriceList, 
HrgB2, 
HrgM2, 
HrgK2, 
HrgB2nominal, 
HrgM2nominal, 
HrgK2nominal, 
IsAktif, 
SyncFlag, 
CreatedBy, 
CreatedOn, 
LastSynch, 
LastUpdatedBy, 
LastUpdatedTime
)
SELECT
NEWID(),
RTRIM(idrec),
NEWID(),
RTRIM(id_stok),
(case  when year(tmt)< 1900 then null else tmt end),
hnet,
persen_b,
persen_m,
persen_k,
nilai_b,
nilai_m,
nilai_k,
1,
id_match,
'Import',
GETDATE(),
GETDATE(),
'Import',
GETDATE()
FROM ISAPunyaJKT.dbo.price_c
GO


UPDATE ISAPalurTradingDb02.dbo.HrgBmkStock2
SET StockRowID = b.RowId
FROM ISAPalurTradingDb02.dbo.HrgBmkStock2 a
INNER JOIN ISAPalurTradingDb02.dbo.Stock b
ON a.StockRecordID = b.IDRecLama
GO


