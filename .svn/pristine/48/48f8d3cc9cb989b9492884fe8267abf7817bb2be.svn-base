/* Author : Anung Satriaji Rahman
   Created Date	: 29 Mei 2012
*/

USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.price_b') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].price_b
GO

SELECT 
	*
INTO ISAPunyaJKT.dbo.price_b
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM price_b')
GO



DELETE FROM [srv_dev011,2802].ISAPalurTradingDb02.dbo.HrgBmkStock0
GO


INSERT INTO [srv_dev011,2802].ISAPalurTradingDb02.dbo.HrgBmkStock0
(
RowID, 
RecordID, 
StockRowID, 
StockRecordID, 
TglAktif, 
TglPasif, 
HrgNet, 
HrgB0, 
HrgM0, 
HrgK0, 
HrgB0nominal, 
HrgM0nominal, 
HrgK0nominal, 
QtyMinB0, 
QtyMinM0, 
QtyMinK0, 
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
tmt,
tmt_pasif,
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
FROM ISAPunyaJKT.dbo.price_b
GO


UPDATE [srv_dev011,2802].ISAPalurTradingDb02.dbo.HrgBmkStock0
SET StockRowID = b.RowId
FROM [srv_dev011,2802].ISAPalurTradingDb02.dbo.HrgBmkStock0 a
INNER JOIN [srv_dev011,2802].ISAPalurTradingDb02.dbo.Stock b
ON a.StockRecordID = b.IDRecLama
GO


