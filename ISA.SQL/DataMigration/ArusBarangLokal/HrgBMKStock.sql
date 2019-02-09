/* Author : Anung Satriaji Rahman
   Created Date	: 29 Mei 2012
*/

USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.price_a') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].price_a
GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.price_a
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM price_a')
GO



DELETE FROM ISAPalurTradingDb02.dbo.HrgBmkStock
GO


INSERT INTO ISAPalurTradingDb02.dbo.HrgBmkStock
(
RowID, 
RecordID, 
StockRowID, 
StockRecordID, 
TglAktif, 
HrgPriceList, 
HrgB1, 
HrgM1, 
HrgK1, 
HrgB1nominal, 
HrgM1nominal, 
HrgK1nominal, 
QtyMinB1, 
QtyMinM1, 
QtyMinK1, 
SyncFlag, 
IsAktif, 
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
qmin_b,
qmin_m,
qmin_k,
id_match,
1,
'Import',
GETDATE(),
GETDATE(),
'Import',
GETDATE()
FROM ISAPunyaJKT.dbo.price_a
GO


UPDATE ISAPalurTradingDb02.dbo.HrgBmkStock
SET StockRowID = b.RowId
FROM ISAPalurTradingDb02.dbo.HrgBmkStock a
INNER JOIN ISAPalurTradingDb02.dbo.Stock b
ON a.StockRecordID = b.IDRecLama
GO

 