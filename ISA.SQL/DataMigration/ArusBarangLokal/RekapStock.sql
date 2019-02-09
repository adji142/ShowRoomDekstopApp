USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[dlapman]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].[dlapman]
GO


SELECT
	*
INTO ISAPunyaJKT.dbo.dlapman
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM dlapman')



DELETE FROM ISAPalurTradingDb02.DBO.RekapStock


--DECLARE @TempRekapStock TABLE
--(
--RowID UNIQUEIDENTIFIER, 
--StockRowID UNIQUEIDENTIFIER, 
--idmain VARCHAR(15),
--TglAwal DATETIME, --tmt
--TglAkhir DATETIME, --tmt1
--StockAwal INT, --awal
--StockAkhir INT, --akhir
--QtyPb INT, -- beli
--QtyRb INT, -- rbeli
--QtyPj INT, -- jual
--QtyRj INT, -- rjual
--QtyMts INT, --mutasi
--QtyKrs INT, -- (kbeli + krjual) - (kjual - krbeli)
--QtyAdj INT, --q_adj
--QtyChecker INT, 
--Cabang VARCHAR(4), --kd_toko
--CreatedOn DATETIME, 
--CreatedBy VARCHAR(250), 
--LastUpdatedBy VARCHAR(250), 
--LastUpdatedTime DATETIME
--)


INSERT INTO ISAPalurTradingDb02.DBO.RekapStock
(
RowID, 
StockRowID, 
TglAwal, --tmt
TglAkhir, --tmt1
StockAwal, --awal
StockAkhir, --akhir
QtyPb, -- beli
QtyRb, -- rbeli
QtyPj, -- jual
QtyRj, -- rjual
QtyMts, --mutasi
QtyKrs, -- (kbeli + krjual) - (kjual + krbeli)
QtyAdj, --q_adj
QtyChecker, 
Cabang, --kd_toko
CreatedOn, 
CreatedBy, 
LastUpdatedBy, 
LastUpdatedTime
)
SELECT
NEWID(),
stk.RowId,
tmt,
tmt1,
awal,
akhir,
beli,
rbeli,
jual,
rjual,
mutasi,
((kbeli + krjual) - (kjual + krbeli)) AS QtyKrs,
q_adj,
0,
kd_toko,
GETDATE(),
'IMPORT',
'IMPORT',
GETDATE()
FROM ISAPunyaJKT.dbo.dlapman dlp
OUTER APPLY
(
	SELECT TOP 1 RowID FROM ISAPalurTradingDb02.DBO.Stock stk WHERE stk.KodeBarang = dlp.idmain
)stk
WHERE tmt between '2012-01-01' AND '2012-12-31'

GO